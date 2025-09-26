using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PhanBaiTap
{

    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public List<SinhVien> qlsv;
        public QuanLySinhVien()
        {
            qlsv = new List<SinhVien>();
        }
        public SinhVien this[int index]
        {
            get { return qlsv[index] as SinhVien; }
            set { qlsv[index] = value; }
        }
        public void Them(SinhVien sv)
        {
            qlsv.Add(sv);
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in qlsv)
            {
                svresult = sv;
                break;
            }
            return svresult;
        }
        //Doc file txt
        public void DocFile(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            using (StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    s = t.Split('|');
                    sv = new SinhVien();
                    sv.MSSV = s[0];
                    sv.HoTenLot = s[1];
                    sv.Ten = s[2];
                    sv.NgaySinh = DateTime.Parse(s[3]);
                    sv.DiaChi = s[8];
                    sv.Lop = s[4];
                    sv.GioiTinh = false;
                    if (s[5].Trim().ToLower() == "1")
                        sv.GioiTinh = true;
                    else 
                        sv.GioiTinh = false;
                        sv.CMND = s[6];
                        sv.SDT = s[7];
                        string[] mh = s[9].Split(',');
                        foreach (string m in mh)
                            sv.MonHoc.Add(m);
                        this.Them(sv);
                    
                }
            }
        }
    }
}
    


