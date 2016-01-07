using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicSettings;

namespace FalloutPrefs
{
    public partial class Form1 : Form
    {
        private CSettings m_iniFile;
        private int m_selectedTabIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdOpen.Filter = "INI files|*.ini";
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                tbxSourceINI.Text = ofdOpen.FileName;
                backupSource(ofdOpen.FileName);
                loadINI(ofdOpen.FileName);
            }
        }

        private void backupSource(string fileName)
        {
            String target = fileName + ".bak";
            try
            {
                File.Copy(fileName, target);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Do you want to overwrite your backup?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    File.Copy(fileName, target, true);
            }
        }

        private void loadINI(String filename)
        {
            m_iniFile = new CSettings(filename);
            m_iniFile.LoadSettings();
            tctrlSettings.Controls.Clear();

            var list = m_iniFile.Attributes.Keys.ToList();
            list.Sort();
            foreach (String attrib in list)
            {
                Point topleft = new Point(4, 4);

                if (m_iniFile.Attributes[attrib].Count < 1)
                    continue;
                TabPage page = new TabPage(attrib);
                page.Name = attrib;
                tctrlSettings.TabPages.Add(page);

                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill;
                panel.Name = "pnl" + attrib;
                page.Controls.Add(panel);

                ListBox listbox = new ListBox();
                listbox.Name = "lbx" + attrib;
                listbox.Width = 300;
                listbox.Height = panel.Height - 8;
                panel.Controls.Add(listbox);
                listbox.Location = topleft;
                List<String> boxItems = new List<String>();
                foreach (String setting in m_iniFile.Attributes[attrib].Keys)
                    boxItems.Add(setting);
                boxItems.Sort();
                foreach (String entry in boxItems)
                    listbox.Items.Add(entry);
                listbox.SelectedIndexChanged += listbox_SelectedIndexChanged;

                topleft = new Point(listbox.Right + 4, listbox.Top);

                // examine/edit
                Label lbl = new Label();
                lbl.Name = "lbl" + attrib;
                lbl.Text = "Field Value:";
                lbl.Width = 200;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                panel.Controls.Add(lbl);
                lbl.Location = topleft;

                topleft.Y += lbl.Height + 4;
                TextBox box = new TextBox();
                box.Width = 300;
                box.Name = "tbx" + attrib;
                panel.Controls.Add(box);
                box.Location = topleft;

                Button btn = new Button();
                topleft.Y = (box.Top - ((btn.Height - box.Height) / 2));
                topleft.X = box.Right + 4;
                btn.Name = "btn" + attrib;
                btn.Text = "Set";
                btn.Click += button_Click;
                panel.Controls.Add(btn);
                btn.Location = topleft;

                // add
                Label lblAdd = new Label();
                lblAdd.Name = "lblAdd" + attrib;
                lblAdd.Text = "Add";
                lblAdd.Width = 200;
                lblAdd.TextAlign = ContentAlignment.MiddleLeft;
                panel.Controls.Add(lblAdd);
                topleft.X = lbl.Left;
                topleft.Y = box.Top + box.Height + 4;
                lblAdd.Location = topleft;

                topleft.Y += lblAdd.Height + 4;
                TextBox boxAddName = new TextBox();
                boxAddName.Width = 200;
                boxAddName.Name = "tbxAdd" + attrib + "Name";
                panel.Controls.Add(boxAddName);
                boxAddName.Location = topleft;

                topleft.X += boxAddName.Width + 4;
                TextBox boxAddVal = new TextBox();
                boxAddVal.Width = 96;
                boxAddVal.Name = "tbxAdd" + attrib + "Value";
                panel.Controls.Add(boxAddVal);
                boxAddVal.Location = topleft;

                Button btnAdd = new Button();
                topleft.Y = (boxAddName.Top - ((btnAdd.Height - boxAddName.Height) / 2));
                topleft.X = boxAddVal.Right + 4;
                btnAdd.Name = "btnAdd" + attrib;
                btnAdd.Text = "Add";
                btnAdd.Click += button_AddClick;
                panel.Controls.Add(btnAdd);
                btnAdd.Location = topleft;

                m_selectedTabIndex = tctrlSettings.SelectedIndex;
            }
        }

        private void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox.SelectedItem == null)
                return;
            String txtBoxName = "tbx" + tctrlSettings.TabPages[m_selectedTabIndex].Name;
            String lblName = "lbl" + tctrlSettings.TabPages[m_selectedTabIndex].Name;
            String setting = listBox.SelectedItem.ToString();
            TextBox txtbox = (TextBox)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(txtBoxName, true)[0];
            Label lbl = (Label)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(lblName, true)[0];
            if (lbl != null)
                lbl.Text = setting;
            if (txtbox != null)
                txtbox.Text = m_iniFile.Attributes[tctrlSettings.TabPages[m_selectedTabIndex].Name][setting].ToString();
        }

        private void button_Click(object sender, EventArgs e)
        {
            String listboxname = "lbx" + tctrlSettings.TabPages[m_selectedTabIndex].Name;
            String txtboxname = "tbx" + tctrlSettings.TabPages[m_selectedTabIndex].Name;
            ListBox lstBox = (ListBox)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(listboxname, true)[0];
            TextBox txtBox = (TextBox)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(txtboxname, true)[0];
            String attribute = tctrlSettings.TabPages[m_selectedTabIndex].Name;
            String setting = "";
            String value = "";
            if (lstBox == null)
                return;
            setting = lstBox.Items[lstBox.SelectedIndex].ToString();
            if (txtBox == null)
                return;
            value = txtBox.Text;

            m_iniFile.Set(attribute, setting, value);
        }

        private void button_AddClick(object sender, EventArgs e)
        {
            String listboxname = "lbx" + tctrlSettings.TabPages[m_selectedTabIndex].Name;
            String txtboxaddname = "tbxAdd" + tctrlSettings.TabPages[m_selectedTabIndex].Name + "Name";
            String txtboxaddval = "tbxAdd" + tctrlSettings.TabPages[m_selectedTabIndex].Name + "Value";
            ListBox lstBox = (ListBox)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(listboxname, true)[0];
            TextBox txtBoxAddname = (TextBox)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(txtboxaddname, true)[0];
            TextBox txtBoxAddvalue = (TextBox)tctrlSettings.TabPages[m_selectedTabIndex].Controls.Find(txtboxaddval, true)[0];
            String attribute = tctrlSettings.TabPages[m_selectedTabIndex].Name;
            String setting = "";
            String value = "";
            if (lstBox == null)
                return;
            if (txtBoxAddname == null)
                return;
            setting = txtBoxAddname.Text;
            value = txtBoxAddvalue.Text;
            m_iniFile.Add(attribute, setting, value);

            lstBox.Items.Clear();
            String[] array = new String[m_iniFile.Attributes[attribute].Keys.Count];
            m_iniFile.Attributes[attribute].Keys.CopyTo(array, 0);
            var list = array.ToList<String>();
            list.Sort();
            foreach (String key in list)
                lstBox.Items.Add(key);
        }

        private void tctrlSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_selectedTabIndex = tctrlSettings.SelectedIndex;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            ofdOpen.Filter = "BAK files|*.bak";
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                String target = ofdOpen.FileName.Replace(".bak", "");
                File.Copy(ofdOpen.FileName, target, true);
                m_iniFile.LoadSettings();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbxSourceINI.Text))
            {
                m_iniFile.SaveSettings();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Form1 form = (Form1)sender;
            Size clientSize = form.ClientSize;
            btnSave.Left = clientSize.Width - btnSave.Width - 12;

            tctrlSettings.Width = clientSize.Width - (2*tctrlSettings.Left);
            tctrlSettings.Height = clientSize.Height - tctrlSettings.Top - 12;
        }
    }
}
