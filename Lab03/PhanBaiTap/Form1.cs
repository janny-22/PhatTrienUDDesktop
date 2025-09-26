using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PhanBaiTap
{
   
    public partial class Form1 : Form
    {
        QuanLySinhVien manager = new QuanLySinhVien();
        public List<SinhVien> qlsv = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
        }
        public void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToLongDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
            //string gt = "Nữ";
            //if (sv.GioiTinh)
            //    gt = "Nam";
            lvitem.SubItems.Add(sv.CMND);
            lvitem.SubItems.Add(sv.SDT);
            lvitem.SubItems.Add(sv.DiaChi);
            string mh = string.Join(",", sv.MonHoc);
            lvitem.SubItems.Add(mh);
            this.lvDS.Items.Add(lvitem);
        }
       
        private void LoadListView()
        {
            this.lvDS.Items.Clear();
            foreach (SinhVien sv in manager.qlsv) 
                ThemSV(sv);
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> mh = new List<string>();
            sv.MSSV = this.mtxtMSSV.Text;
            sv.HoTenLot = this.txtHoTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Lop = this.cbbLop.Text;
            if (rdNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            sv.CMND = this.mtxtCMND.Text;
            sv.SDT = this.mtxtSDT.Text;/*
            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                if (clbMonHoc.GetItemChecked(i))
                    mh.Add(clbMonHoc.Items.ToString());*/
            // ✅ Lấy đúng tên môn học
            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
            {
                if (clbMonHoc.GetItemChecked(i))
                {
                    mh.Add(clbMonHoc.Items[i].ToString());
                }
            }
            sv.MonHoc = mh;
            return sv;
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.Lop = lvitem.SubItems[4].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.DiaChi = lvitem.SubItems[8].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            sv.CMND = lvitem.SubItems[6].Text;
            sv.SDT = lvitem.SubItems[7].Text;
            List<string> mh = new List<string>();
            string[] s = lvitem.SubItems[9].Text.Split(',');
            foreach (string t in s)
                mh.Add(t.Trim());
            sv.MonHoc = mh;
            return sv;
        }
        private void HienThi(List<SinhVien> ds)
        {
           
            lvDS.Items.Clear();
            foreach (SinhVien sv in ds)
            {
                ListViewItem item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoTenLot);
                item.SubItems.Add(sv.Ten);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                string gt = sv.GioiTinh ? "Nam" : "Nữ";
                item.SubItems.Add(gt);
                item.SubItems.Add(sv.CMND);
                item.SubItems.Add(sv.SDT);
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(string.Join(", ", sv.MonHoc));

                lvDS.Items.Add(item);
            }
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MSSV;
            this.txtHoTenLot.Text = sv.HoTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cbbLop.Text = sv.Lop;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            this.mtxtCMND.Text = sv.CMND;
            this.mtxtSDT.Text = sv.SDT;
            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                this.clbMonHoc.SetItemChecked(i, false);
            foreach (string s in sv.MonHoc)
            {
                for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                    if (s.CompareTo(this.clbMonHoc.Items[i]) == 0)
                        this.clbMonHoc.SetItemChecked(i, true);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new List<SinhVien>();
            lvDS.View = View.Details;
            lvDS.FullRowSelect = true;
            lvDS.GridLines = true;
            //Them cac cot
            lvDS.Columns.Add("MSSV", 100);
            lvDS.Columns.Add("Họ tên lót", 120);
            lvDS.Columns.Add("Tên", 80);
            lvDS.Columns.Add("Ngày sinh", 100);
            lvDS.Columns.Add("Lớp", 80);
            lvDS.Columns.Add("Giới tính", 80);
            lvDS.Columns.Add("CMND", 120);
            lvDS.Columns.Add("SDT", 100);
            lvDS.Columns.Add("Địa chỉ", 150);
            lvDS.Columns.Add("Môn học", 200);
            manager.DocFile("SinhVien.txt");
            LoadListView();
        }

        private void lvDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count=this.lvDS.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem=this.lvDS.SelectedItems[0];
                SinhVien sv=GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }
        
        private void lvSinhVien_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int count = this.lvDS.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvDS.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }
        private bool KiemTraTT()
        {
            if (string.IsNullOrWhiteSpace(mtxtMSSV.Text) ||
               string.IsNullOrWhiteSpace(txtHoTenLot.Text) ||
               string.IsNullOrWhiteSpace(txtTen.Text) ||
               string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
               string.IsNullOrWhiteSpace(cbbLop.Text) ||
               string.IsNullOrWhiteSpace(mtxtCMND.Text) ||
               string.IsNullOrWhiteSpace(mtxtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (mtxtMSSV.Text.Length != 7)
            {
                MessageBox.Show("MSSV phải gồm 7 số!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (mtxtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải gòm 10 số.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thiếu thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (clbMonHoc.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 môn học.", "Thiếu thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            DateTime ngaySinh = dtpNgaySinh.Value.Date;
            if (ngaySinh >= DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không hợp lệ.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string dk = Interaction.InputBox("Nhập điều kiện (MSSV/Tên/Lớp): ", "Tìm kiếm", "");
            if (string.IsNullOrWhiteSpace(dk)) return;
            foreach (ListViewItem item in lvDS.Items)
            {
                if (item.Text.Contains(dk) || item.SubItems[2].Text.Contains(dk) || item.SubItems[5].Text.Contains(dk))
                    item.BackColor = Color.Yellow;
                else
                    item.BackColor = Color.White;
            }
        }
      
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraTT()) return;
            var sv = GetSinhVien();
            qlsv.Add(sv);
            ThemSV(sv);
           manager.DocFile("SinhVien.txt");   // Lưu lại
            MessageBox.Show("Thêm sinh viên thành công!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            SinhVien svMoi = GetSinhVien();
            if (!KiemTraTT()) return;
            string mssv = mtxtMSSV.Text.Trim();
            var sv = qlsv.FirstOrDefault(x => x.MSSV == mssv);
            if (sv != null)
            {
                sv.HoTenLot = svMoi.HoTenLot;
                sv.Ten = svMoi.Ten;
                sv.NgaySinh = svMoi.NgaySinh;
                sv.DiaChi = svMoi.DiaChi;
                sv.Lop = svMoi.Lop;
                sv.GioiTinh = svMoi.GioiTinh;
                sv.CMND = svMoi.CMND;
                sv.SDT = svMoi.SDT;
                sv.MonHoc = svMoi.MonHoc;
                ThemSV(svMoi);
               manager.DocFile("SinhVien.txt");   // Lưu lại
                MessageBox.Show("Cập nhật sinh viên thành công!");
            }
            else
                MessageBox.Show("Không tìm thấy MSSV để cập nhật!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
