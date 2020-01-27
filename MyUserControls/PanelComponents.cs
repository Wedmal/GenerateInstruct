using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.MyUserControls
{
    public partial class PanelComponents : UserControl
    {
        private bool isGenerateComponents = false;
        public PanelComponents()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Вызываем все необходимые методы:
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnLoad(EventArgs e)
        {
            isGenerateComponents = await generateComponents();
            base.OnLoad(e);
        }

        private Task<bool> generateComponents() 
        {
            //for (int i = 0; i < 1000000000; i++) 
            //{
            //    System.Threading.Thread.Sleep(10);
            //}
            return TaskEx.FromResult(false);
        }
        
    }
}
