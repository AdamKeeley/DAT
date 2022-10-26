using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataControlsLib
{
    public static class Static_Helper
    {
        /// <summary>
        /// Prevent the cursor from being positioned in the middle of a masked textbox when 
        /// the user clicks in it, if the control is empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void enter_MaskedTextBox(MaskedTextBox maskedtextbox_Target)
        {
            if (maskedtextbox_Target.Text == "  /  /")
                maskedtextbox_Target.Select(0, 0);
        }

        /// <summary>
        /// Removes expired selectable items from a combobox. 
        /// Expired items are those in sql db with an entry under ValidTo field.
        /// Retains currently selected item, even if expired.
        /// </summary>
        /// <param name="combobox_Target"></param>
        public static void combobox_RemoveLegacyItems(ComboBox combobox_Target)
        {
            // get currently assigned properties
            string combobox_ValueMember = combobox_Target.ValueMember;
            string combobox_DisplayMember = combobox_Target.DisplayMember;

            // put current datasource into new datatable
            DataTable itemsToFilter = new DataTable();
            itemsToFilter = combobox_Target.DataSource as DataTable;

            // filter new data table to only retain non-expired items (where ValidTo is null) and currently selected value
            // ensuring that currently elected items remain selected.
            DataView filteredItems = new DataView(itemsToFilter);
            if (combobox_Target.SelectedIndex > -1)
            {
                int currentValue = (int)combobox_Target.SelectedValue;
                filteredItems.RowFilter = $"[ValidTo] is null or {combobox_ValueMember} = {currentValue}";
                combobox_Target.DataSource = filteredItems.ToTable();
                combobox_Target.ValueMember = combobox_ValueMember;
                combobox_Target.DisplayMember = combobox_DisplayMember;
                combobox_Target.SelectedValue = currentValue;
            }
            else
            {
                filteredItems.RowFilter = $"[ValidTo] is null";
                combobox_Target.DataSource = filteredItems.ToTable();
                combobox_Target.ValueMember = combobox_ValueMember;
                combobox_Target.DisplayMember = combobox_DisplayMember;
                combobox_Target.SelectedIndex = -1;
            }
        }


        public static void enter_TextBox(TextBox textbox_Target)
        {
            if (textbox_Target.Text == "£0.00")
                textbox_Target.Select(textbox_Target.Text.Length, 0);
        }

        /// <summary>
        /// Formats text as a currency and pushes entered numbers left from right of decimal, if last position is selected.
        /// </summary>
        /// <param name="textbox_Target"></param>
        public static void textChanged_TextBox_Currency(TextBox textbox_Target)
        {
            if (textbox_Target.SelectionStart == textbox_Target.Text.Length)
            {
                //Remove previous formatting, or the decimal check will fail including leading zeros
                string value = textbox_Target.Text.Replace(",", "")
                    .Replace("£", "").Replace(".", "").TrimStart('0');
                decimal ul;
                //Check we are indeed handling a number
                if (decimal.TryParse(value, out ul))
                {
                    //Format the text as currency
                    ul /= 100;
                    textbox_Target.Text = string.Format(CultureInfo.CreateSpecificCulture("en-GB"), "{0:C2}", ul);
                    textbox_Target.Select(textbox_Target.Text.Length, 0);
                }
            }

        }

    }
}
