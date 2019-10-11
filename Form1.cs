using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
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
            P_x = 0;
            P_y = 0;
            Sign = 0;
            PointNumber = 0;
            IsGetSeed = 0;
            Stack_x = 0;
            Stack_y = 0;
        }

        private void CG_Win_Load(object sender, EventArgs e)
        {
            groupBox2.MouseDown += new MouseEventHandler(groupBox2_MouseDown);
            //groupBox2.MouseUp += new MouseEventHandler(groupBox1_MouseUp);
        }

        void groupBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Sign == 1)
            {
                if (e.X % 10 >= 5)
                    P_x = e.X / 10 + 1;
                else
                    P_x = e.X / 10;

                if ((this.groupBox2.Height - e.Y) % 10 >= 5)
                    P_y = (this.groupBox2.Height - e.Y) / 10;
                else
                    P_y = (this.groupBox2.Height - e.Y) / 10 - 1;
                if (P_x == BordPoint[0, 0] && P_y == BordPoint[1, 0])
                {
                    Sign = 0;
                    IsGetSeed = 1;
                    int tmpNumber = PointNumber;
                    for (int i=0;i< tmpNumber; i++)
                    {
                        if (i == tmpNumber - 1)
                        {
                            NEW_DDA(BordPoint[0, 0], BordPoint[1, 0], BordPoint[0, i], BordPoint[1, i]);
                        }
                        else
                            NEW_DDA(BordPoint[0, i], BordPoint[1, i], BordPoint[0, i + 1], BordPoint[1, i + 1]);
                    }
                }
                else
                {
                    BordPoint[0, PointNumber] = P_x;
                    BordPoint[1, PointNumber] = P_y;
                    PointNumber++;
                    MyDraw(P_x, P_y);
                    ShowMessage("X=" + P_x + "  Y=" + P_y+"  ");
                }
            }
            else if(IsGetSeed==1)
            {
                if (e.X % 10 >= 5)
                    P_x = e.X / 10 + 1;
                else
                    P_x = e.X / 10;

                if ((this.groupBox2.Height - e.Y) % 10 >= 5)
                    P_y = (this.groupBox2.Height - e.Y) / 10;
                else
                    P_y = (this.groupBox2.Height - e.Y) / 10 - 1;
                MyDraw(P_x, P_y);
                Push(P_x, P_y);
                IsGetSeed = 0;
                while (top > 0)
                {
                    Pop();
                    x_Right = Stack_x + FillLineRight(Stack_x, Stack_y);
                    x_Left = Stack_x - FillLineLeft(Stack_x, Stack_y);
                    SearchNewSeed(x_Left, x_Right,Stack_y);
                }
            }
            else
            {
                //
            }
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
            Pen LinePen3 = new Pen(Color.FromArgb(255,0,0), 1);
        }

        private void MyDraw(int x, int y)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Red, 1);
            Brush b = new SolidBrush(Color.Red);//声明的画刷
            graphics_Line2.DrawEllipse(PointPen, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            graphics_Line2.FillEllipse(b, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
        }

        private void SeedMyDraw(int x, int y)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Yellow, 1);
            Brush b = new SolidBrush(Color.Yellow);//声明的画刷
            graphics_Line2.DrawEllipse(PointPen, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            graphics_Line2.FillEllipse(b, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            BordPoint[0, PointNumber] = x;
            BordPoint[1, PointNumber] = y;
            ShowMessage("种子点-->X=" + x + "  Y=" + y);
            PointNumber++;
        }

        private void NEW_MyDraw(int x,int y)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Red, 1);
            Brush b = new SolidBrush(Color.Red);//声明的画刷
            graphics_Line2.DrawEllipse(PointPen, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            graphics_Line2.FillEllipse(b, x * 10 - 3, (32 - y) * 10 - 3, 5, 5);
            BordPoint[0, PointNumber] = x;
            BordPoint[1, PointNumber] = y;
            PointNumber++;
        }

        private void CenterMyDraw(int x, int y)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Red, 1);
            Brush b = new SolidBrush(Color.Red);//声明的画刷
            graphics_Line2.DrawEllipse(PointPen, 150 + x * 10 - 3, (33 - 16 + y) * 10 - 3, 5, 5);
            graphics_Line2.FillEllipse(b, 150 + x * 10 - 3, (33 - 16 + y) * 10 - 3, 5, 5);
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

        private void DrawRealRound(int r)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Black, 2);
            graphics_Line2.DrawEllipse(PointPen, 150 - r*10, 170 - r*10, 20*r, 20*r);
        }

        private void DrawRealEillpse(int a,int b)
        {
            Graphics graphics_Line2 = this.groupBox2.CreateGraphics();
            Pen PointPen = new Pen(Color.Black, 2);
            graphics_Line2.DrawEllipse(PointPen, 150 - a * 10, 170 - b * 10, 20 * a, 20 * b);
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
                Sign = 0;
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
                Sign = 0;
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
                Sign = 0;
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
                if (Eill_L > 15||Eill_S>15)
                {
                    MessageBox.Show("超出范围！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Ellipse_MiddlePoint();
                }
            }
            else if(LineCheckList.GetItemChecked(6))
            {
                Sign = 1;
                PointNumber = 0;
                ResetStack();
                for(int i=0;i<900;i++)
                {
                    BordPoint[0,i] = 0;
                    BordPoint[1,i] = 0;
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
                        MyDraw((int)tmp3,30-y2);
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

        private void NEW_DDA(int S_x,int S_y,int E_x,int E_y)
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
                        NEW_MyDraw(x1, 30 - (int)tmp2);
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
                    for (y2 = 30 - S_y; y2 <= 30 - E_y; y2++)
                    {
                        float tmp3;
                        tmp3 = x2 + (float)0.5;
                        ShowMessage("X=" + x2 + "   Y=" + y2 + "  K=" + k2);
                        NEW_MyDraw((int)tmp3, 30 - y2);
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
                        NEW_MyDraw(x3, (int)tmp2);
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
                    for (y4 = S_y; y4 <= E_y; y4++)
                    {
                        float tmp3;
                        tmp3 = x4 + (float)0.5;
                        ShowMessage("X=" + x4 + "   Y=" + y4 + "  K=" + k4);
                        NEW_MyDraw((int)tmp3, y4);
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
            int Rx, Ry;
            listBox1.Items.Clear();
            float d;
            Rx = 0;
            Ry = R;
            d = (float)1.25 - R;
            ShowMessage("X=" + Rx + "   Y=" + Ry + "   D=" + d);
            RoudDraw(Rx, Ry);
            while(Rx<=Ry)
            {
                if (d < 0)
                    d = d + 2 * Rx + 3;
                else
                {
                    d = d + 2 * (Rx - Ry) + 5;
                    Ry--;
                }
                Rx++;
                ShowMessage("X=" + Rx + "   Y=" + Ry + "   D=" + d);
                RoudDraw(Rx, Ry);
            }
            DrawRealRound(R);

        }

        private void Round_Bresenham()
        {
            int Rx, Ry, det, detHD, detDV, Sign;
            listBox1.Items.Clear();
            Rx = 0;Ry = R;
            detHD = 0;
            detDV = 0;
            det = 2 * (1 - R);
            while(Ry>=0)
            {
                ShowMessage("X=" + Rx + "   Y=" + Ry + "  DET=" + det + "   DetHD=" + detHD + "   DetDV=" + detDV);
                RoudDraw(Rx, Ry);
                if (det < 0)
                {
                    detHD = 2 * (det + Ry) - 1;
                    if (detHD <= 0)
                        Sign = 1;
                    else
                        Sign = 2;
                }
                else if (det > 0)
                {
                    detDV = 2 * (det - Rx) - 1;
                    if (detDV < 0)
                        Sign = 2;
                    else
                        Sign = 3;
                }
                else
                    Sign = 2;
                switch(Sign)
                {
                    case 1:
                        Rx++;
                        det = det + 2 * Rx + 1;
                        break;
                    case 2:
                        Rx++;
                        Ry--;
                        det = det + 2 * (Rx - Ry + 1);
                        break;
                    case 3:
                        Ry--;
                        det = det + (-2 * Ry + 1);
                        break;
                }
            }
            DrawRealRound(R);
        }

        private void Ellipse_MiddlePoint()
        {
            listBox1.Items.Clear();
            int a, b, x, y;
            float det;
            a = Eill_L;
            b = Eill_S;
            x = 0;
            y = Eill_S;
            det = b * b + a * a * (-b + (float)0.25);
            EllipseDraw(x, y);
            ShowMessage("X=" + x + "   Y=" + y + "   Det=" + det);
            while(y>=0)
            {
                if (b * b * (x + 1) < a * a * (y - (float)0.5))
                {
                    if (det < 0)
                    {
                        det += b * b * (2 * x + 3);
                    }
                    else
                    {
                        det += b * b * (2 * x + 3) + a * a * (-2 * y + 2);
                        y--;
                    }
                    x++;
                    ShowMessage("X=" + x + "   Y=" + y + "   Det=" + det);
                    EllipseDraw(x, y);
                }
                else
                {
                    break;
                }
            }
            while(y>=0)
            {
                det = b * b * (x + 0.5f) * (x + 0.5f) + a * a * (y - 1) * (y - 1) - a * a * b * b;
                if(det>0)
                {
                    det += a * a * (-2 * y + 3);
                }
                else
                {
                    det += b * b * (2 * x + 2) + a * a * (-2 * y + 3);
                    x++;
                }
                y--;
                ShowMessage("X=" + x + "   Y=" + y + "   Det=" + det);
                EllipseDraw(x, y);
            }
            DrawRealEillpse(a, b);
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

        private void ResetStack()
        {
            top = 0;
            for(int i=0;i<30;i++)
            {
                PointStack[0, i] = 0;
                PointStack[1, i] = 0;
            }
        }

        private void Push(int x,int y)
        {
            PointStack[0, top] = x;
            PointStack[1, top] = y;
            top++;
            SeedMyDraw(x, y);
            //MessageBox.Show("Push X=" + x + "  Y=" + y+"  Top="+top);
        }

        private void Pop()
        {
            Stack_x = PointStack[0, top-1];
            Stack_y = PointStack[1, top-1];
            //MessageBox.Show("弹出" + Stack_x + " " + Stack_y);
            top--;
        }

        private int FillLineRight(int Seed_x,int Seed_y)
        {
            int time = 0;
            while (true)
            {
                Seed_x++;
                if (IsBorder(Seed_x, Seed_y))
                { return time; }
                else
                {
                    NEW_MyDraw(Seed_x, Seed_y);
                    time++;
                }
            }
        }
        private int FillLineLeft(int Seed_x, int Seed_y)
        {
            int time = 0;
            while (true)
            {
                Seed_x--;
                if (IsBorder(Seed_x, Seed_y))
                { return time; }
                else
                {
                    NEW_MyDraw(Seed_x, Seed_y);
                    time++;
                }
            }
        }

        private bool IsBorder(int x,int y)
        {
            int IsBorderNum = 0;
            for(int tmp=0;tmp<PointNumber;tmp++)
            {
                if (x == BordPoint[0, tmp] && y == BordPoint[1, tmp])
                {
                    IsBorderNum = 1;
                    break;
                }
                else
                    IsBorderNum = 0;
            }
            if (IsBorderNum == 1)
                return true;
            else
                return false;
        }

        private void SearchNewSeed(int BordLeft,int BordRight,int RightNow_y)
        {
            int tmp = BordLeft;
            int tmp_x = 0;
            int tmp_y = 0;
            RightNow_y++;
            while (tmp <= BordRight)
                {
                    if (!IsBorder(tmp, RightNow_y))
                    {
                        for (int i = 0; i < PointNumber; i++)
                        {
                            if (RightNow_y == BordPoint[1, i])
                                if (tmp < BordPoint[0, i])
                                {
                                    tmp_x = tmp;
                                    tmp_y = RightNow_y;
                                }
                        }
                    }
                    tmp++;
                }
            if(tmp_x!=0&&tmp_y!=0)
            Push(tmp_x, tmp_y);
            //FillLineRight(BordLeft, RightNow_y);
            //FillLineLeft(BordLeft, RightNow_y);
            RightNow_y -=2;
            tmp_x = 0;
            tmp_y = 0;
            tmp = BordLeft;
            while (tmp <= BordRight)
                {
                    if (!IsBorder(tmp, RightNow_y))
                    {
                        for (int i = 0; i < PointNumber; i++)
                        {
                            if (RightNow_y == BordPoint[1, i])
                                if (tmp < BordPoint[0, i])
                                {
                                    tmp_x = tmp;
                                    tmp_y = RightNow_y;
                                }
                        }
                    }
                    tmp++;
                }
            if (tmp_x != 0 && tmp_y != 0)
                Push(tmp_x, tmp_y);
            //FillLineRight(BordLeft, RightNow_y);
            //FillLineLeft(BordLeft, RightNow_y);
        }

    }
}
