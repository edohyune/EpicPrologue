using Dapper;
using Lib;
using System.CodeDom;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.Control;

namespace Ctrls
{
    public class UCField : BindingSource
    {
        //FrameWrok에서 인스턴스를 구분하는데 사용하는 변수 
        #region Properties Browseable(false) ----------------------------------------------------------
        [Browsable(true)]
        public string frwId { get; set; }
        [Browsable(true)]
        public string frmId { get; set; }
        [Browsable(true)]
        public string thisNm { get; set; }
        [Browsable(false)]
        private object OSearchParam; //object 검색조건을 저장하는 변수
        [Browsable(false)]
        private DynamicParameters DSearchParam; //dynamicParameters 검색조건을 저장하는 변수
        #endregion

        public UCField()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            try
            {
                //frwId, frmId, thisNm이 없으면 초기화를 하지 않는다.
                if (string.IsNullOrEmpty(frwId) || string.IsNullOrEmpty(frmId) || string.IsNullOrEmpty(thisNm))
                {
                    Lib.Common.gMsg = $"UCField초기화에 필요한 정보가 없습니다.";
                    return;
                }
                else
                {
                    ResetField();
                }
            }
            catch (Exception)
            {
                Lib.Common.gMsg = $"UCField초기화에 문제가 있습니다.";
                throw;
            }
        }

        private Form? FindParentForm(Control control)
        {
            while (control != null && !(control is Form))
            {
                control = control.Parent;
            }
            return control as Form;
        }

        private void ResetField()
        {
            Lib.Common.gMsg = $"UCField의 기본정보가 셋팅되었습니다. {frwId}.{frmId}.{thisNm}";
            //T는 필드셋에서 사용하는 데이터 모델이다. 
            //  - 필드셋의 컨트롤 정보를 불러온다.(frwId, frmId, ctrlNm)
            //  - 필드셋의 컨트롤 정보를 이용해 바인딩을 한다.
            //  - 필드셋의 컨트롤 정보를 이용해 컨트롤을 초기화한다.
            return;
        }

        public void Open<T>()
        {
            return;
            //FieldSet에 데이터를 넣는다.
            //  - FieldSet의 Select 쿼리를 불러온다. 
            //  - 쿼리를 실행하기 위한 추가 파라미터를 불러온다.
            //  - 쿼리를 실행한다.
            //  - 바인딩 된 FieldSet에 데이터를 넣는다.
        }

        public void Clear()
        {
            //FieldSet을 초기화한다.
            return;
        }

        private void NewDocument()
        {
            //FieldSet을 초기화하고 신규데이터를 받을 준비를 한다. 
            return;
        }

        public void Save<T>()
        {
            //FieldSet을 저장한다. 
            //  - DefaultValue를 가져온다. 
            //  - FieldSet의 ChangedFlag의 MdlStat를 이용해 구분한다. 
            //  - insert update 쿼리를 불러와서 실행한다.
            return;
        }

        public void Delete()
        {
            return;
            //FieldSet을 삭제한다. 
            //  - FieldSet의 ChangedFlag의 MdlStat를 이용해 구분한다.
            //  - delete 쿼리를 불러와서 실행한다.
        }
    }
}
