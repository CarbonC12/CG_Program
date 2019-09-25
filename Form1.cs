using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Program
{
    public partial class CG_Win : Form
    {
        public CG_Win()
        {
            InitializeComponent();
            LineCheckList.SetItemChecked(0, true);
            S_x = 0;
            S_y = 0;
            E_x = 0;
            E_y = 0;
            R = 0;
            Eill_L = 0;
            Eill_S = 0;
        }



        private void CG_Win_Load(object sender, EventArgs e)
        {
            //
        }








        private void TabPage2_Click(object sender, EventArgs e)
        {
            //
        }

        private void TabPage2_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void GroupBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen LinePen2 = new Pen(Color.FromArgb(174, 189, 191), 1);
            //绘制矩阵
            for (int i = 20; i <= 320; i += 10)
            {
                graphics_Line2.DrawLine(LinePen2, 0, i, 300, i);
            }
            for (int i = 0; i <= 300; i += 10)
                graphics_Line2.DrawLine(LinePen2, i, 20, i, 320);
        }

        private void MyDraw(int x, int y)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Red, 1);
            Brush b = new SolidBrush(Color.Red);//声明的画刷
            graphics_Line2.DrawEllipse(PointPen, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            graphics_Line2.FillEllipse(b, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            System.Threading.Thread.Sleep(100);
        }

        private void CenterMyDraw(int x, int y)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Red, 1);
            Brush b = new SolidBrush(Color.Red);//声明的画刷
            graphics_Line2.DrawEllipse(PointPen, 150 + x * 10 - 3, (32 - 16 + y) * 10 - 3, 5, 5);
            graphics_Line2.FillEllipse(b, 150 + x * 10 - 3, (32 - 16 + y) * 10 - 3, 5, 5);
            System.Threading.Thread.Sleep(100);
        }

        private void RoudDraw(int x, int y)
        {
            CenterMyDraw(x, y);
            CenterMyDraw(x, -y);
            CenterMyDraw(-x, y);
            CenterMyDraw(-x, -y);
            CenterMyDraw(y, x);
            CenterMyDraw(y, -x);
            CenterMyDraw(-y, x);
            CenterMyDraw(-y, -x);
        }

        private void EllipseDraw(int x, int y)
        {
            CenterMyDraw(x, y);
            CenterMyDraw(x, -y);
            CenterMyDraw(-x, -y);
            CenterMyDraw(-x, y);
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {
            //
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            graphics_Line2.Clear(Color.White);
            GroupBox2_Paint(null, null);
            if (LineCheckList.GetItemChecked(0) || LineCheckList.GetItemChecked(1)||LineCheckList.GetItemChecked(2))
            {
                try
                {
                    S_x = Convert.ToInt32(IN__S_X.Text);
                    S_y = Convert.ToInt32(IN_S_Y.Text);
                    E_x = Convert.ToInt32(IN_E_X.Text);
                    E_y = Convert.ToInt32(IN_E_Y.Text);
                }
                catch (Exception ec)
                {
                    MessageBox.Show("输入了非数字！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (S_x > 30 || E_x > 30 || S_y > 30 || E_y > 30)
                {
                    MessageBox.Show("超出范围！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (LineCheckList.GetItemChecked(0))
                        DDA();
                    else if (LineCheckList.GetItemChecked(1))
                        Bresenham();
                    else if(LineCheckList.GetItemChecked(2))
                        New_Bresenham();
                }
            }
            else if(LineCheckList.GetItemChecked(3)||LineCheckList.GetItemChecked(4))
            {
                try
                {
                    R = Convert.ToInt32(IN_R.Text);
                }
                catch (Exception ec)
                {
                    MessageBox.Show("输入了非数字！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (R>15)
                {
                    MessageBox.Show("超出范围！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (LineCheckList.GetItemChecked(3))
                        Round_MiddlePoint();
                    else if (LineCheckList.GetItemChecked(4))
                        Round_Bresenham();
                }
            }
            else if(LineCheckList.GetItemChecked(5))
            {
                try
                {
                    Eill_L = Convert.ToInt32(IN_EL_L.Text);
                    Eill_S = Convert.ToInt32(IN_EL_S.Text);
                }
                catch (Exception ec)
                {
                    MessageBox.Show("输入了非数字！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (R > 15)
                {
                    MessageBox.Show("超出范围！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Ellipse_MiddlePoint();
                }
            }
        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DDA()
        {
            int tmp;
            listBox1.Items.Clear();
            if (E_x <= S_x)
            {
                tmp = E_x;
                E_x = S_x;
                S_x = tmp;

                tmp = E_y;
                E_y = S_y;
                S_y = tmp;
            }
            float det_x, det_y; 
            det_x = E_x - S_x;
            det_y = E_y - S_y;
            if(det_y<0)
            {
                int x1;
                float y1;
                float k;
                S_y = 30 - S_y;
                E_y = 30 - E_y;
                x1 = S_x;
                y1 = S_y;
                det_y = 0 - det_y;
                if (det_x >= det_y)
                {
                    k = det_y / det_x;
                    for (x1 = S_x; x1 <= E_x; x1++)
                    {
                        float tmp2;
                        tmp2 = y1 + (float)0.5;
                        ShowMessage("X=" + x1 + "   Y=" + y1 + "  K=" + k);
                        MyDraw(x1, 30-(int)tmp2);
                        y1 = y1 + k;
                    }
                }
                else
                {
                    float x2;
                    int y2;
                    float k2;
                    S_y = 30 - S_y;
                    E_y = 30 - E_y;
                    x2 = S_x;
                    y2 = S_y;
                    k2 = det_x / det_y;
                    for (y2 = 30-S_y; y2 <= 30-E_y; y2++)
                    {
                        float tmp3;
                        tmp3 = x2 + (float)0.5;
                        ShowMessage("X=" + x2 + "   Y=" + y2 + "  K=" + k2);
                        MyDraw((int)tmp3,29-y2);
                        x2 = x2 + k2;
                    }
                }
            }
            else
            {
                int x3;
                float y3;
                float k3;
                x3 = S_x;
                y3 = S_y;
                if (det_x >= det_y)
                {
                    k3 = det_y / det_x;
                    for (x3 = S_x; x3 <= E_x; x3++)
                    {
                        float tmp2;
                        tmp2 = y3 + (float)0.5;
                        ShowMessage("X=" + x3 + "   Y=" + y3 + "  K=" + k3);
                        MyDraw(x3,(int)tmp2);
                        y3 = y3 + k3;
                    }
                }
                else
                {
                    float x4;
                    int y4;
                    float k4;
                    x4 = S_x;
                    y4 = S_y;
                    k4 = det_x / det_y;
                    for (y4 =S_y; y4 <=E_y; y4++)
                    {
                        float tmp3;
                        tmp3 = x4 + (float)0.5;
                        ShowMessage("X=" + x4 + "   Y=" + y4 +"  K=" + k4);
                        MyDraw((int)tmp3,y4);
                        x4 = x4 + k4;
                    }
                }
            }

            

        }

        private void Bresenham()
        {
            int tmp;
            listBox1.Items.Clear();
            if (E_x <= S_x)
            {
                tmp = E_x;
                E_x = S_x;
                S_x = tmp;

                tmp = E_y;
                E_y = S_y;
                S_y = tmp;
            }

            float det_x, det_y;
            det_x = E_x - S_x;
            det_y = E_y - S_y;
            if (det_y < 0)
            {
                det_y = 0 - det_y;
                if (det_x >= det_y)
                {
                    float k, e;
                    int x, y;
                    k = det_y / det_x;
                    e = -0.5f;
                    x = S_x;
                    y = 30-S_y;
                    for (int i = 0; i <= det_x; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   K=" + k + "   E=" + e);
                        MyDraw(x, 30-y);
                        x = x + 1;
                        e = e + k;
                        if (e >= 0)
                        {
                            y++;
                            e = e - 1;
                        }
                    }

                }
                else
                {
                    float k, e;
                    int x, y;
                    k = det_x / det_y;
                    e = -0.5f;
                    x = S_x;
                    y = 30-S_y;
                    for (int i = 0; i <= det_y; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   K=" + k + "   E=" + e);
                        MyDraw(x, 30-y);
                        y = y + 1;
                        e = e + k;
                        if (e >= 0)
                        {
                            x++;
                            e = e - 1;
                        }
                    }
                }
            }
            else
            {
                if (det_x >= det_y)
                {
                    float k, e;
                    int x, y;
                    k = det_y / det_x;
                    e = -0.5f;
                    x = S_x;
                    y = S_y;
                    for(int i=0;i<=det_x;i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   K=" + k + "   E=" + e);
                        MyDraw(x, y);
                        x = x + 1;
                        e = e + k;
                        if(e>=0)
                        {
                            y++;
                            e = e - 1;
                        }
                    }

                }
                else
                {
                    float k, e;
                    int x, y;
                    k = det_x / det_y;
                    e = -0.5f;
                    x = S_x;
                    y = S_y;
                    for (int i = 0; i <= det_y; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   K=" + k  + "   E=" + e);
                        MyDraw(x, y);
                        y = y + 1;
                        e = e + k;
                        if (e >= 0)
                        {
                            x++;
                            e = e - 1;
                        }
                    }
                }
            }

        }
        private void New_Bresenham()
        {
            
            int tmp;
            listBox1.Items.Clear();
            if (E_x <= S_x)
            {
                tmp = E_x;
                E_x = S_x;
                S_x = tmp;

                tmp = E_y;
                E_y = S_y;
                S_y = tmp;
            }
            int det_x, det_y, line_e, x, y;
            det_x = E_x - S_x;
            det_y = E_y - S_y;
            line_e = 0 - det_x;
            x = S_x;
            y = S_y;
            if (det_y < 0)
            {
                S_y = 30 - S_y;
                E_y = 30 - E_y;
                x = S_x;
                y = S_y;
                det_y = 0 - det_y;
                if (det_x >= det_y)
                {
                    for (int i = 0; i <= det_x; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   E=" + line_e);
                        MyDraw(x, 30-y);
                        
                        x++;
                        line_e = line_e + 2 * det_y;
                        if (line_e >= 0)
                        {
                            y++;
                            line_e = line_e - 2 * det_x;
                            //MessageBox.Show("e" + line_e);
                        }

                    }
                }
                else
                {
                    line_e = 0 - det_y;
                    for (int i = 0; i <= det_y; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   E=" + line_e);
                        MyDraw(x, 30-y);
                        y++;
                        line_e = line_e + 2 * det_x;
                        if (line_e >= 0)
                        {
                            x++;
                            line_e = line_e - 2 * det_y;
                        }

                    }
                }
            }
            else
            {
                if (det_x >= det_y)
                {
                    for (int i = 0; i <= det_x; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   E=" + line_e);
                        MyDraw(x, y);
                        x++;
                        line_e = line_e + 2 * det_y;
                        if (line_e >= 0)
                        {
                            y++;
                            line_e = line_e - 2 * det_x;
                        }

                    }
                }
                else
                {
                    line_e = 0 - det_y;
                    for (int i = 0; i <= det_y; i++)
                    {
                        ShowMessage("X=" + x + "   Y=" + y + "   E=" + line_e);
                        MyDraw(x, y);
                        y++;
                        line_e = line_e + 2 * det_x;
                        if (line_e >= 0)
                        {
                            x++;
                            line_e = line_e - 2 * det_y;
                        }

                    }
                }
            }
        }

        private void Round_MiddlePoint()
        {


        }

        private void Round_Bresenham()
        {

        }

        private void Ellipse_MiddlePoint()
        {
            
        }

        private void LineCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for(int i=0;i<LineCheckList.Items.Count;i++)
            {
                if (i != e.Index)
                    LineCheckList.SetItemChecked(i, false);
            }
        }

        private void ShowMessage(string str)
        {
            listBox1.Items.Insert(0,str);
            System.Threading.Thread.Sleep(100);
            Application.DoEvents();

        }
    }
}
