using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit;
using Lib;
using DevExpress.Office.Utils;
using Lib.Repo;
using System.Runtime.Intrinsics.Arm;
using System.Data;

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
                g10.DataSource = frmWrkRepo.GetByFrwFrm(Lib.Common.gFrameWorkId, "GridSet");
            }
        }
        private FrmWrk selectedDoc { get; set; }
        private void g10_UCFocusedRowChanged(object sender, int preIndex, int rowIndex, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Common.gMsg = "g10_UCFocusedRowChanged";
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            selectedDoc = view.GetFocusedRow() as FrmWrk;

            if (selectedDoc != null)
            {
                SetWrkForm();
            }
        }

        private void SetWrkForm()
        {
            rtDelete.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "D").Query;
            rtInsert.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "C").Query;
            rtSelect.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "R").Query;
            rtModel.Text  = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "M").Query;
            rtUpdate.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "U").Query;
        }

        private void pnlSelect_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "R",
                    Query = rtSelect.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "R",
                    Query = rtSelect.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
            else if (e.Button.Properties.Caption == "Make Field")
            {
                using (var db = new GaiaHelper())
                {
                    DataSet dSet = db.GetGridColumns(new { FrwId = selectedDoc.FrwId, FrmId = selectedDoc.FrmId, WrkId = selectedDoc.WrkId, CRUDM = "R" });
                    string deleteSql = @"delete from ATZ300 where Sys_cd=@sys and Frm_id=@frm and Wkset_id=@wkset and Ctrl_ty='Column'";
                    db.OpenExecute(deleteSql, new { sys = OpenSys, frm = OpenFrm, wkset = OpenWk });
                    string insert300Sql = @"insert into ATZ300 
                                               (Sys_cd, Frm_id, Ctrl_id, Ctrl_ty, Title, Wkset_id, Wkset_ty)
                                        select @Sys_cd, @Frm_id, @Ctrl_id, @Ctrl_ty, @Title, @Wkset_id, @Wkset_ty";
                    foreach (DataColumn cols in dSet.Tables[0].Columns)
                    {
                        db.OpenExecute(insert300Sql, new
                        {
                            Sys_cd = OpenSys,
                            Frm_id = OpenFrm,
                            Ctrl_id = column.ColumnName,
                            Ctrl_ty = "Column",
                            Title = column.ColumnName,
                            Wkset_id = OpenWk,
                            Wkset_ty = "Field"
                        });
                    }
                }
                ucTab1.SelectedTabPageIndex = 1;
            }
        }
        private void pnlInsert_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "C",
                    Query = rtInsert.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "C",
                    Query = rtInsert.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void pnlUpdate_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "U",
                    Query = rtUpdate.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "U",
                    Query = rtUpdate.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void pnlDelete_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "D",
                    Query = rtDelete.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "D",
                    Query = rtDelete.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void pnlModel_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "M",
                    Query = rtModel.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "M",
                    Query = rtModel.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void g10_UCSelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Common.gMsg = "g10_UCSelectionChanged";
        }
    }
}
