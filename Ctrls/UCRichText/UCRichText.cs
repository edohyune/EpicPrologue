using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lib;
using DevExpress.XtraRichEdit.Services;
using DevExpress.Office.Utils;
using Lib.Repo;
using static DevExpress.Accessibility.LookupPopupAccessibleObject;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCContentChanged")]
    public class UCRichText : DevExpress.XtraRichEdit.RichEditControl, INotifyPropertyChanged
    {
        #region Properties Browsable(flase) -------------------------------------------------------->>
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)]
        private string thisNm { get; set; }
        [Category("A UserController Property"), Description("Bind Text"), Browsable(false)]
        public string BindText
        {
            get
            {
                string str = (this.Text == null) ? string.Empty : this.Text;
                return str;
            }
            set
            {
                if (this.Text != value)
                {
                    this.Text = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
        #region Properties Browsable(true) --------------------------------------------------------->>
        [Category("A UserController Property"), Description("Default Text")] //chk
        public override string Text
        {
            get
            {
                string str = (base.Text == null) ? string.Empty : base.Text;
                return str;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.BindText = value;  // Text가 업데이트 될 때 BindText도 업데이트
                }   
            }
        }
        [Category("A UserController Property"), Description("Necessary")] //chk
        private bool NeedYn { get; set; }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return !(this.ReadOnly);
            }
            set
            {
                this.ReadOnly = !value;
            }
        }
        [Category("A UserController Property"), Description("Visiable")] //chk
        public bool ShowYn
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }
        #endregion

        public UCRichText(ISyntaxHighlightService syntax)
        {
            Initialize();
            this.ReplaceService<ISyntaxHighlightService>(syntax);
        }
        public UCRichText()
        {
            Initialize();
        }
        private void Initialize()
        {
            this.Dock = DockStyle.Fill;
            this.Name = "rtSelect";
            this.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.Modified = true;
            this.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;

            this.Options.Search.RegExResultMaxGuaranteedLength = 500;
            this.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            this.ContentChanged += UCRichText_ContentChanged;
            this.TextChanged += UCRichText_TextChanged;

            HandleCreated += UCRichText_HandleCreated;
        }

        private void UCRichText_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Common.gFrameWorkId;

            Form? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";
            thisNm = this.Name;

            if (!string.IsNullOrEmpty(frwId))
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            try
            {
                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, thisNm);
                if (wrkFld != null)
                {
                    this.ShowYn = wrkFld.ShowYn;
                    this.NeedYn = wrkFld.NeedYn;
                    this.EditYn = wrkFld.EditYn;
                    this.Text = wrkFld.DefaultText;
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCRichText_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : ";
                Lib.Common.gMsg = $"{ex.Message}";
                throw;
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public delegate void delEventContentChanged(object Sender, EventArgs e);   // delegate 선언
        public event delEventContentChanged UCContentChanged;   // event 선언
        private void UCRichText_ContentChanged(object? sender, EventArgs e)
        {
            if (UCContentChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCContentChanged.Invoke(this, e);
            }
        }
        private void UCRichText_TextChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(BindText));
            UCContentChanged?.Invoke(this, e);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
