using BMS.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class FormManager : IFormManager
    {
        private readonly IServiceProvider _serviceProvider;

        public FormManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowForm<T>(Form parent) where T : Form
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.Show();
                existingForm.BringToFront();
                CenterForm(existingForm);
                return;
            }

            parent.IsMdiContainer = true;
            var newForm = _serviceProvider.GetRequiredService<T>();
            newForm.MdiParent = parent;

            newForm.Show();
        }


        public void ShowFormDialog<T>() where T : Form
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.Show();
                existingForm.BringToFront();
                CenterForm(existingForm);
                return;
            }

          
            var newForm = _serviceProvider.GetRequiredService<T>();
          


            newForm.Show();
        }


        public void ShowDialogForm<T>(Form owner) where T : Form
        {
            using (var form = _serviceProvider.GetRequiredService<T>())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(owner);
            }
        }

        private static void CenterForm(Form form)
        {
            if (form.StartPosition != FormStartPosition.CenterScreen)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                return;
            }

            var screen = Screen.FromControl(form);
            int x = (screen.Bounds.Width - form.Width) / 2;
            int y = (screen.Bounds.Height - form.Height) / 2;
            form.Location = new Point(x, y);
        }
    }
}

