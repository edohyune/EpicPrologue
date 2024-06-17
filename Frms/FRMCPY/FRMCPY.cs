using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Frms
{
    public partial class FRMCPY : UserControl
    {
        public FRMCPY()
        {
            InitializeComponent();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            //Source폴더의 선택은 Source.cs 파일을 선택, 프로젝트 이름과 네임스페이스 추출
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // 초기 디렉토리 설정
                openFileDialog.Filter = "C# files (*.cs)|*.cs"; // .cs 파일만 표시
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 파일 경로를 텍스트 박스에 표시
                    txtSourcePath.Text = Path.GetDirectoryName(openFileDialog.FileName);

                    // 선택된 .cs 파일 읽기
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    // 클래스 이름 추출
                    Regex classRegex = new Regex(@"class\s+([^\s{]+)");
                    Match classMatch = classRegex.Match(fileContent);
                    if (classMatch.Success)
                    {
                        txtSourceClass.Text = classMatch.Groups[1].Value;
                    }

                    // 네임스페이스 추출
                    Regex namespaceRegex = new Regex(@"namespace\s+([^\s{]+)");
                    Match namespaceMatch = namespaceRegex.Match(fileContent);
                    if (namespaceMatch.Success)
                    {
                        txtSourceNmSpace.Text = namespaceMatch.Groups[1].Value;
                    }
                }
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtDestinationPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourcePath.Text) || 
                string.IsNullOrEmpty(txtSourceClass.Text) || 
                string.IsNullOrEmpty(txtSourceNmSpace.Text) ||
                string.IsNullOrEmpty(txtDestinationPath.Text) || 
                string.IsNullOrEmpty(txtDestinationClass.Text) || 
                string.IsNullOrEmpty(txtDestinationNmSpace.Text))
            {
                MessageBox.Show("모든 값을 입력해주세요.");
                return;
            }

            string finalDestinationPath = Path.Combine(txtDestinationPath.Text, txtDestinationClass.Text);

            // 목적지 폴더가 이미 존재하는지 확인하고, 존재하지 않으면 생성
            if (!Directory.Exists(finalDestinationPath))
            {
                Directory.CreateDirectory(finalDestinationPath);
            }

            CopyDirectory(txtSourcePath.Text, finalDestinationPath, txtSourceClass.Text, txtDestinationClass.Text);

            //파일 수정
            RemoveProjectProperties(finalDestinationPath);

            ModifyCompileUpdate(finalDestinationPath, txtSourceClass.Text + ".cs", txtDestinationClass.Text + ".cs");

            UpdateDesignerFile(finalDestinationPath, txtSourceClass.Text, txtDestinationClass.Text, txtDestinationNmSpace.Text);

            UpdateCsFile(finalDestinationPath, txtSourceClass.Text, txtDestinationClass.Text, txtSourceNmSpace.Text, txtDestinationNmSpace.Text);

            UpdateNamespaceInDirectory(finalDestinationPath, txtSourceClass.Text, txtDestinationClass.Text);
        }

        // 폴더를 재귀적으로 복사하는 메서드
        private static void CopyDirectory(string sourceDir, string destinationDir, string sourceclass, string destinationclass)
        {
            // 목적지 폴더 생성
            Directory.CreateDirectory(destinationDir);

            // 파일 복사
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);

                if (fileName.Contains(sourceclass))
                {
                    fileName = fileName.Replace(sourceclass, destinationclass);
                }

                string destFile = Path.Combine(destinationDir, fileName);
                File.Copy(file, destFile, true);
            }

            // 하위 폴더 복사
            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(directory);
                if (dirName != "bin" && dirName != "obj") // bin과 obj 폴더는 제외
                {
                    string destDir = Path.Combine(destinationDir, dirName);
                    CopyDirectory(directory, destDir, sourceclass, destinationclass);
                }
            }
        }

        public static void RemoveProjectProperties(string projectDirectory)
        {
            // 디렉토리 내에서 첫 번째 .csproj 파일 찾기
            string csprojFilePath = Directory.GetFiles(projectDirectory, "*.csproj", SearchOption.AllDirectories).FirstOrDefault();

            if (string.IsNullOrEmpty(csprojFilePath))
            {
                return;
            }

            // .csproj 파일 내용 읽기
            string csprojContent = File.ReadAllText(csprojFilePath);

            // AssemblyName, RootNamespace, ProjectName 태그가 존재하면 해당 로우 삭제
            csprojContent = Regex.Replace(csprojContent, @"<ProjectName>.*?</ProjectName>\s*", string.Empty, RegexOptions.Singleline);
            csprojContent = Regex.Replace(csprojContent, @"<AssemblyName>.*?</AssemblyName>\s*", string.Empty, RegexOptions.Singleline);
            csprojContent = Regex.Replace(csprojContent, @"<RootNamespace>.*?</RootNamespace>\s*", string.Empty, RegexOptions.Singleline);

            // 변경된 내용을 다시 파일에 쓰기
            File.WriteAllText(csprojFilePath, csprojContent);

            Console.WriteLine($"Updated .csproj file: {csprojFilePath}");
        }
        public static void ModifyCompileUpdate(string projectDirectory, string oldFileName, string newFileName)
        {
            string csprojFilePath = Directory.GetFiles(projectDirectory, "*.csproj.user", SearchOption.AllDirectories).FirstOrDefault();

            // .csproj 파일을 XDocument 객체로 로드합니다.
            XDocument csprojXml = XDocument.Load(csprojFilePath);
            XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";

            // <Compile Update="Grid004.cs"> 요소를 찾아서 'Update' 속성을 수정합니다.
            var compileItem = csprojXml.Descendants(msbuild + "Compile")
                                       .Where(x => (string)x.Attribute("Update") == oldFileName)
                                       .FirstOrDefault();

            if (compileItem != null)
            {
                compileItem.SetAttributeValue("Update", newFileName);
                csprojXml.Save(csprojFilePath); // 변경사항을 파일에 저장합니다.
                Console.WriteLine("Compile Update changed successfully.");
            }
            else
            {
                Console.WriteLine("Specified file not found in the project.");
            }
        }

        public static void UpdateDesignerFile(string projectDirectory, string oldClassName, string newClassName, string newNamespace)
        {
            string filePath = Directory.GetFiles(projectDirectory, $"{newClassName}.Designer.cs", SearchOption.AllDirectories).FirstOrDefault();
            try
            {
                // 파일의 전체 텍스트를 읽어옵니다.
                string content = File.ReadAllText(filePath);

                // 네임스페이스 변경
                content = Regex.Replace(content, $"namespace\\s+{Regex.Escape(oldClassName)}", $"namespace {newNamespace}");

                // 클래스 이름 변경
                content = Regex.Replace(content, $"partial class\\s+{Regex.Escape(oldClassName)}", $"partial class {newClassName}");

                // 특정 컨트롤 속성 변경 (예: Name)
                content = Regex.Replace(content, $"Name = \"{oldClassName}\";", $"Name = \"{newClassName}\";");

                // 변경된 내용을 파일에 다시 쓰기
                File.WriteAllText(filePath, content);

                Console.WriteLine("Designer file updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating the designer file: " + ex.Message);
            }
        }
        public static void UpdateCsFile(string projectDirectory, string oldClassName, string newClassName, string oldNamespace, string newNamespace)
        {
            string filePath = Directory.GetFiles(projectDirectory, $"{newClassName}.cs", SearchOption.AllDirectories).FirstOrDefault();
            try
            {
                // 파일의 전체 텍스트를 읽어옵니다.
                string content = File.ReadAllText(filePath);

                // 네임스페이스 변경
                string namespacePattern = $@"\bnamespace\s+{Regex.Escape(oldNamespace)}";
                content = Regex.Replace(content, namespacePattern, $"namespace {newNamespace}");

                // 클래스 이름 변경
                string classPattern = $@"\bclass\s+{Regex.Escape(oldClassName)}";
                content = Regex.Replace(content, classPattern, $"class {newClassName}");

                // 정규 표현식을 사용하여 클래스 이름 찾기 및 교체
                // 쌍따옴표로 둘러싸인 클래스 이름을 포함한 모든 인스턴스를 대상으로 합니다.
                string pattern = $"\"{Regex.Escape(oldClassName)}\"";
                content = Regex.Replace(content, pattern, $"\"{newClassName}\"");

                // 클래스 이름이 코드의 다른 부분에서도 사용될 수 있으므로 일반적인 참조도 교체
                content = Regex.Replace(content, $@"\b{Regex.Escape(oldClassName)}\b", newClassName);

                // 변경된 내용을 파일에 다시 쓰기
                File.WriteAllText(filePath, content);

                Console.WriteLine("CS file updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating the CS file: " + ex.Message);
            }
        }
        public static void UpdateNamespaceInDirectory(string directoryPath, string oldClassName, string newClassName)
        {
            try
            {
                // 지정된 디렉토리와 그 하위 디렉토리에서 모든 .cs 파일을 찾습니다.
                string[] files = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    // 제외할 파일 이름 결정
                    string excludeFile1 = $"{newClassName}.cs";
                    string excludeFile2 = $"{newClassName}.Designer.cs";

                    // 현재 파일 이름 추출
                    string currentFileName = Path.GetFileName(file);

                    // 제외할 파일인지 확인
                    if (currentFileName.Equals(excludeFile1, StringComparison.OrdinalIgnoreCase) ||
                        currentFileName.Equals(excludeFile2, StringComparison.OrdinalIgnoreCase))
                    {
                        continue; // 이 파일은 처리하지 않고 다음 파일로 넘어갑니다.
                    }

                    // 파일의 전체 텍스트를 읽어옵니다.
                    string content = File.ReadAllText(file);

                    // 네임스페이스와 클래스 이름 패턴을 찾아 교체
                    string pattern = $@"Frms\.Models\.{Regex.Escape(oldClassName)}";
                    content = Regex.Replace(content, pattern, $"Frms.Models.{newClassName}");

                    // 변경된 내용을 파일에 다시 쓰기
                    File.WriteAllText(file, content);
                }

                Console.WriteLine("All eligible files updated successfully in the directory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating the files in the directory: " + ex.Message);
            }
        }
    }
}
