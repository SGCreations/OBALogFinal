using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OBALog.Windows
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class ApplicationUtilities
    {
        public static bool IsNotEmpty(this TextBox control)
        {
            return !string.IsNullOrEmpty(control.Text);
        }

        public static bool IsEmpty(this TextBox control)
        {
            return string.IsNullOrEmpty(control.Text);
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNotEmpty(this TextEdit control)
        {
            return !string.IsNullOrEmpty(control.Text);
        }

        public static bool IsEmpty(this TextEdit control)
        {
            return string.IsNullOrEmpty(control.Text.Trim());
        }

        public static int ToInt(this TextEdit control)
        {
            return Convert.ToInt32(control.Text.Trim());
        }

        public static int? ToIntNullable(this TextEdit control)
        {
            return (control.Text.Trim().IsEmpty()) ? (int?)null : (control.Text.Trim().All(Char.IsDigit) ? Convert.ToInt32(control.Text.Trim()) : (int?)null);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        
        public static int ToIntWithNull(this string value)
        {
            return Convert.ToInt32(value.IsEmpty() ? "0" : value);
        }

        public static bool ToBool(this string value)
        {
            return Convert.ToBoolean(value);
        }
        public static TimeSpan ToTimeSpan(this string value)
        {
            return TimeSpan.Parse(value);
        }
        public static DateTime ToDateTime(this string value)
        {
            return Convert.ToDateTime(value);
        }

        public static string DateFromString(this string value)
        {
            return (value.IsEmpty() || value == "0000-00-00 00:00:00") ? null : Convert.ToDateTime(value).ToShortDateString();
        }

        public static int? ToIntNullable(this string value)
        {
            return (value.Trim().IsEmpty()) ? (int?)null : (value.Trim().All(Char.IsDigit) ? Convert.ToInt32(value.Trim()) : (int?)null);
        }

        public static int? ToIntNullable(this LookUpEdit value)
        {
            return (value.EditValue == null) ? (int?)null : (value.EditValue.ToString().Trim().All(Char.IsDigit) ?
                Convert.ToInt32(value.EditValue.ToString().Trim()) : (int?)null);
        }

        public static void Clear(this TextEdit edit)
        {
            edit.Text = string.Empty;
        }
        public static void Clear(this LabelControl edit)
        {
            edit.Text = string.Empty;
        }
        public static void Clear(this LookUpEdit edit)
        {
            edit.Properties.DataSource = null;
        }

        public static void Clear(this ListBoxControl Control)
        {
            Control.DataSource = null;
            Control.Items.Clear();
        }

        public static void ClearAndFocus(this TextEdit edit)
        {
            edit.Text = string.Empty;
            edit.Focus();
        }

        public static void SelectFirstIndex(this ComboBoxEdit edit)
        {
            edit.SelectedIndex = edit.Properties.Items.Count > 0 ? 0 : -1;
        }

        public static void SelectFirstIndex(this LookUpEdit lkupEdit)
        {
            if (lkupEdit.Properties.DataSource is DataTable)
            {
                lkupEdit.Properties.ForceInitialize();
                lkupEdit.ItemIndex = ((DataTable)lkupEdit.Properties.DataSource).Rows.Count > 0 ? 0 : -1;
            }
        }

        public static string NullIfEmpty(this TextEdit control)
        {
            return string.IsNullOrEmpty(control.Text.Trim()) ? null : control.Text.Trim();
        }

        public static string NullIfEmpty(this string value)
        {
            return string.IsNullOrEmpty(value.Trim()) ? null : value.Trim();
        }

        public static void Reset(this DXValidationProvider Validator, XtraForm form)
        {
            if (form.Visible)
            {
                IList<Control> controls = Validator.GetInvalidControls();
                while (controls.Count > 0)
                {
                    Validator.RemoveControlError(controls[controls.Count - 1]);
                }
            }
        }

        public static int? ToIntNullable(this CustomLookUpEdit value)
        {
            return (value.IsEmpty()) ? (int?)null : (value.EditValue.ToString().All(Char.IsDigit) ? Convert.ToInt32(value.EditValue.ToString().Trim()) : (int?)null);
        }

        public static bool? NullIfIndeterminate(this CheckEdit control)
        {
            switch (control.CheckState)
            {
                case CheckState.Indeterminate:
                    return null;
                case CheckState.Checked:
                    return true;
                default:
                    return false;
            }
        }

        public static bool? NullIfTrue(this CheckEdit control)
        {
            return control.Checked ? (bool?)null : false;
        }

        public static DialogResult ShowMessageSplash(UniversalEnum.MessageTypes type, string message, IWin32Window owner, string title = null)
        {
            // DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

            switch (type)
            {
                case UniversalEnum.MessageTypes.Success:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Success" : title, MessageBoxButtons.OK, MessageBoxIcon.None);
                case UniversalEnum.MessageTypes.Information:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Information" : title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                case UniversalEnum.MessageTypes.Error:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Error" : title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                case UniversalEnum.MessageTypes.Warning:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Warning" : title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                case UniversalEnum.MessageTypes.YesNo:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Message" : title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                case UniversalEnum.MessageTypes.YesNoCancel:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Message" : title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                case UniversalEnum.MessageTypes.Exclamation:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Message" : title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                default:
                    return XtraMessageBox.Show(owner, message, title.IsEmpty() ? "Information" : title, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        public static DialogResult ShowMessage(UniversalEnum.MessageTypes type, string message, string title = null)
        {
            // DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

            switch (type)
            {
                case UniversalEnum.MessageTypes.Success:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Success" : title, MessageBoxButtons.OK, MessageBoxIcon.None);
                case UniversalEnum.MessageTypes.Information:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Information" : title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                case UniversalEnum.MessageTypes.Error:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Error" : title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                case UniversalEnum.MessageTypes.Warning:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Warning" : title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                case UniversalEnum.MessageTypes.YesNo:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Message" : title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                case UniversalEnum.MessageTypes.YesNoCancel:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Message" : title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                case UniversalEnum.MessageTypes.Exclamation:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Message" : title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                default:
                    return XtraMessageBox.Show(message, title.IsEmpty() ? "Information" : title, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }


        public static string GetFormattedDateString(this DateEdit control, string format)
        {
            return control.Text.Trim().IsEmpty() ? null : control.DateTime.ToString(format);
        }
        public static string GetFormattedDateString(this DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);

                            object a = Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType);

                            propertyInfo.SetValue(obj, a, null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static void DisplayForm(XtraForm form, XtraForm owner)
        {
            if (!CheckOpened(form.Name, form))
            {
                form.ShowInTaskbar = false;
                form.Owner = owner;
                form.Show();
            }
        }

        private static bool CheckOpened(string name, XtraForm form)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    form.Dispose();
                    frm.Focus();
                    return true;
                }
            }

            return false;
        }

        public static void CheckFormDirty(Action inpMethod, bool isDirty)
        {
            if (isDirty)
            {
                if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, UniversalVariables.UnsavedData) == DialogResult.Yes)
                {
                    inpMethod();
                }
            }
            else
            {
                inpMethod();
            }
        }

        public static bool CheckFormDirtyClose(Func<bool> inpMethod, bool isDirty)
        {
            return isDirty ? ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, UniversalVariables.UnsavedData) == DialogResult.Yes ? inpMethod() : false : inpMethod();
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        public static System.Drawing.Image byteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
    }
}
