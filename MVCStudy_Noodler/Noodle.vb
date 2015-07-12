Imports NUnit.Framework
Imports System.Linq
Imports System.Linq.Expressions

<testfixture>
Public Class Noodle
    <Test> Public Sub CountDown()
        Assert.AreEqual("10 9 8 7 6 5 4 3 2 1 0", DoCountDown(10))

    End Sub

    Private Function DoCountDown(pStart As Integer) As String
        Dim n As New List(Of String)
        For i As Integer = pStart To 0 Step -1
            n.Add(i)
        Next
        Return String.Join(" ", n)
    End Function

End Class
