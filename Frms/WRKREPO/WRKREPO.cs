using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit;
using Lib;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using static System.Windows.Forms.Design.AxImporter;
using DevExpress.Diagram.Core.Native.Generation;
using System.ComponentModel;
using Lib.Repo;

namespace Frms
{
    public partial class WRKREPO : UserControl
    {
        private DevExpress.XtraRichEdit.RichEditControl rtSelect;
        private DevExpress.XtraRichEdit.RichEditControl rtInsert;
        private DevExpress.XtraRichEdit.RichEditControl rtUpdate;
        private DevExpress.XtraRichEdit.RichEditControl rtDelete;
        private DevExpress.XtraRichEdit.RichEditControl rtModel;


        public WRKREPO()
        {
            InitializeComponent();
            InitializeRichTextEditor();
            ucTab2.SelectedTabPageIndex = 0;

            //OpenRichTextFieldSelect(rtxtSelect, @"");
            //            OpenRichTextFieldSelect(rtxtInsert, @"");
            //            OpenRichTextFieldSelect(rtxtUpdate, @"");
            //            OpenRichTextFieldSelect(rtxtDelete, @"");

            //            OpenRichTextFieldSelect(rtxtModel, @"
            //namespace Lib
            //{
            //    public class CustomSyntaxHighlightService : ISyntaxHighlightService
            //    {
            //        readonly Document document;

            //        Regex _keywords;
            //        Regex _strings;
            //        Regex _comments;

            //        public CustomSyntaxHighlightService(Document document)
            //        {
            //            this.document = document;

            //            // C# Keywords
            //            string[] keywords = { ""abstract"", ""as"", ""base"", ""bool"", ""break"", ""byte"", ""case"", ""catch"", ""char"", ""checked"", ""class"", ""const"", ""continue"", ""decimal"", ""default"", ""delegate"", ""do"", ""double"", ""else"", ""enum"", ""event"", ""explicit"", ""extern"", ""false"", ""finally"", ""fixed"", ""float"", ""for"", ""foreach"", ""goto"", ""if"", ""implicit"", ""in"", ""int"", ""interface"", ""internal"", ""is"", ""lock"", ""long"", ""namespace"", ""new"", ""null"", ""object"", ""operator"", ""out"", ""override"", ""params"", ""private"", ""protected"", ""public"", ""readonly"", ""ref"", ""return"", ""sbyte"", ""sealed"", ""short"", ""sizeof"", ""stackalloc"", ""static"", ""string"", ""struct"", ""switch"", ""this"", ""throw"", ""true"", ""try"", ""typeof"", ""uint"", ""ulong"", ""unchecked"", ""unsafe"", ""ushort"", ""using"", ""virtual"", ""void"", ""volatile"", ""while"" };
            //            this._keywords = new Regex(@""\b("" + string.Join(""|"", keywords.Select(w => Regex.Escape(w))) + @"")\b"");

            //            // Strings
            //            this._strings = new Regex(@""@?""""([^""""\\]|\\.)*""""|'([^'\\]|\\.)*'"");

            //            // Comments
            //            this._comments = new Regex(@""//.*|/\*[\s\S]*?\*/"");
            //        }

            //        public void ForceExecute() => Execute();

            //        public void Execute()
            //        {
            //            List<SyntaxHighlightToken> cSharpTokens = ParseTokens();
            //            document.ApplySyntaxHighlight(cSharpTokens);
            //        }

            //        private List<SyntaxHighlightToken> ParseTokens()
            //        {
            //            // ... (ParseTokens, CombineWithPlainTextTokens, CreateToken, IsRangeInTokens, IsIntersect 메서드는 SQL 예제와 동일)
            //        }
            //    }
            //}
            //");

        }

        private void InitializeRichTextEditor()
        {
            rtSelect = new DevExpress.XtraRichEdit.RichEditControl();
            rtInsert = new DevExpress.XtraRichEdit.RichEditControl();
            rtUpdate = new DevExpress.XtraRichEdit.RichEditControl();
            rtDelete = new DevExpress.XtraRichEdit.RichEditControl();
            rtModel = new DevExpress.XtraRichEdit.RichEditControl();

            rtSelect.Dock = DockStyle.Fill;
            rtSelect.Name = "rtSelect";
            rtSelect.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtSelect.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtSelect.Modified = true;
            rtSelect.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtSelect.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtSelect.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtSelect.Document.DefaultCharacterProperties.FontName = "Consolas";
            rtSelect.Document.DefaultCharacterProperties.FontSize = 16;
            rtSelect.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtSelect.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtInsert.Dock = DockStyle.Fill;
            rtInsert.Name = "rtInsert";
            rtInsert.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtInsert.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtInsert.Modified = true;
            rtInsert.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtInsert.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtInsert.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtInsert.Document.DefaultCharacterProperties.FontName = "Consolas";
            rtInsert.Document.DefaultCharacterProperties.FontSize = 16;
            rtInsert.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtInsert.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtUpdate.Dock = DockStyle.Fill;
            rtUpdate.Name = "rtUpdate";
            rtUpdate.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtUpdate.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtUpdate.Modified = true;
            rtUpdate.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtUpdate.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtUpdate.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtUpdate.Document.DefaultCharacterProperties.FontName = "Consolas";
            rtUpdate.Document.DefaultCharacterProperties.FontSize = 16;
            rtUpdate.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtUpdate.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtDelete.Dock = DockStyle.Fill;
            rtDelete.Name = "rtDelete";
            rtDelete.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtDelete.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtDelete.Modified = true;
            rtDelete.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtDelete.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtDelete.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtDelete.Document.DefaultCharacterProperties.FontName = "Consolas";
            rtDelete.Document.DefaultCharacterProperties.FontSize = 16;
            rtDelete.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtDelete.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtModel.Dock = DockStyle.Fill;
            rtModel.Name = "rtModel";
            rtModel.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtModel.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtModel.Modified = true;
            rtModel.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtModel.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtModel.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtModel.Document.DefaultCharacterProperties.FontName = "Consolas";
            rtModel.Document.DefaultCharacterProperties.FontSize = 16;
            rtModel.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtModel.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            pnlSelect.Controls.Add(rtSelect);
            pnlInsert.Controls.Add(rtInsert);
            pnlUpdate.Controls.Add(rtUpdate);
            pnlDelete.Controls.Add(rtDelete);
            pnlModel.Controls.Add(rtModel);
        }

        private void OpenRichTextFieldSelect(RichEditControl rtxt, string query)
        {
            if (rtxt == rtModel)
            {
                rtxt.ReplaceService<ISyntaxHighlightService>(new CS_Syntax(rtxt.Document));
            }
            else
            {
                rtxt.ReplaceService<ISyntaxHighlightService>(new SQL_Syntax(rtxt.Document));
            }
            rtxt.Text = query;
        }

        private void ucPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Open")
            {
                var frmWrkRepo = new FrmWrkRepo();
                g10.DataSource = frmWrkRepo.GetByFrwFrm(Lib.Common.gFrameWorkId, "WrkRepo");
            }
        }

        private void g10_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {

        }
    }
}
