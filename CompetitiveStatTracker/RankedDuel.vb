﻿Public Class RankedDuel

    Function CalculateKDA(ByVal K As Integer, ByVal D As Integer, ByVal A As Integer)

        Dim KDA As Single = 0

        If D = 0 Then

            KDA = ((A / 2) + K)
        Else

            KDA = ((A / 2) + K) / D
        End If

        Return KDA
    End Function

    Private Sub RankedDuel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'SmiteDataSet.QueTypes' Puede moverla o quitarla según sea necesario.
        Me.QueTypesTableAdapter.Fill(Me.SmiteDataSet.QueTypes)
        'TODO: esta línea de código carga datos en la tabla 'SmiteDataSet.Teams' Puede moverla o quitarla según sea necesario.
        Me.TeamsTableAdapter.Fill(Me.SmiteDataSet.Teams)
        'TODO: esta línea de código carga datos en la tabla 'SmiteDataSet.Tiers' Puede moverla o quitarla según sea necesario.
        Me.TiersTableAdapter.Fill(Me.SmiteDataSet.Tiers)
        'TODO: esta línea de código carga datos en la tabla 'SmiteDataSet.DuelMatches' Puede moverla o quitarla según sea necesario.
        Me.DuelMatchesTableAdapter.Fill(Me.SmiteDataSet.DuelMatches)

    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click

        SmiteMenu.Show()
        Me.Close()
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click

        Dim KDA As Single = CalculateKDA(Val(Kills.Text), Val(Deaths.Text), Val(Assists.Text))

        Me.DuelMatchesTableAdapter.InsertDuelMatch(Tier.SelectedValue, Winner.SelectedValue, Que.SelectedValue, Val(Kills.Text), Val(Deaths.Text), Val(Assists.Text), KDA, Comment.Text)
        Me.DuelMatchesTableAdapter.Fill(Me.SmiteDataSet.DuelMatches)

        Me.Hide()
        AddDuelMatch.Show()

    End Sub

    Private Sub Modify_Click(sender As Object, e As EventArgs) Handles Modify.Click

        Dim KDA As Single = CalculateKDA(Val(Kills.Text), Val(Deaths.Text), Val(Assists.Text))

        Me.DuelMatchesTableAdapter.ModifyDuelMatch(Tier.SelectedValue, Winner.SelectedValue, Que.SelectedValue, Val(Kills.Text), Val(Deaths.Text), Val(Assists.Text), KDA, Comment.Text, Val(MatchID.Text))
        Me.DuelMatchesTableAdapter.Fill(Me.SmiteDataSet.DuelMatches)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        AddDuelMatch.Show()
        Me.Close()
    End Sub

    Private Sub Stats_Click(sender As Object, e As EventArgs) Handles Stats.Click

        DuelStatScreen.Show()
        Me.Hide()
    End Sub
End Class