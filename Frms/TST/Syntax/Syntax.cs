using DevExpress.CodeParser;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraRichEdit.API.Native;
using EpicV003.Lib.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Match = System.Text.RegularExpressions.Match;
using EpicV003.Lib.Syntax;

namespace Frms.TST
{
    public partial class Syntax : UserControl
    {

        public Syntax()
        {
            InitializeComponent();
        }


        private void btnTEST01_Click(object sender, EventArgs e)
        {
            SyntaxExtractor extractor = new SyntaxExtractor();
            SyntaxMatch variables = extractor.ExtractVariables(txtMemo.Text);

            foreach (var kvp in variables.OPatternMatch)
            {
                Lib.Common.gMsg = ($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        private void btnTEST02_Click(object sender, EventArgs e)
        {
            SyntaxExtractor extractor = new SyntaxExtractor();
            SyntaxMatch variables = extractor.ExtractVariables(txtMemo.Text);

            foreach (var kvp in variables.DPatternMatch)
            {
                Lib.Common.gMsg = ($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }


        private void btnTEST03_Click(object sender, EventArgs e)
        {
            SyntaxExtractor extractor = new SyntaxExtractor();
            SyntaxMatch variables = extractor.ExtractVariables(txtMemo.Text);

            foreach (var kvp in variables.GPatternMatch)
            {
                Lib.Common.gMsg = ($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        private void richEditControl1_RtfTextChanged(object sender, EventArgs e)
        {

        }

        private void richEditControl1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
