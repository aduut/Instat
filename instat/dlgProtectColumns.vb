﻿' Instat-R
' Copyright (C) 2015
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License k
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations
Public Class dlgProtectColumns

    Public bFirstLoad As Boolean = True

    Private Sub dlgProtectColumns_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If bFirstLoad Then
            InitialiseDialog()
            SetDefaults()
            TestOKEnabled()
            bFirstLoad = False
        Else
            '       ReopenDialog()
        End If
        autoTranslate(Me)
    End Sub

    'Private Sub ReopenDialog()

    'End Sub

    Private Sub TestOKEnabled()

        If ucrReceiverforProtectedColumns.IsEmpty Then
            ucrBase.OKEnabled(True)
        End If
        'If ucrReceiverforProtectedColumns_SelectionChanged() Then
        ucrBase.OKEnabled(True)
        'End If

        If ucrBase.cmdReset.Enabled Then
            ucrBase.OKEnabled(True)
        End If

    End Sub

    Private Sub InitialiseDialog()

        ucrReceiverforProtectedColumns.Selector = ucrSelectorforProtectedColumns
        ucrReceiverforProtectedColumns.SetMeAsReceiver()
        ucrBase.clsRsyntax.SetFunction(frmMain.clsRLink.strInstatDataObject & "$set_protected_columns")

    End Sub

    Private Sub SetDefaults()

        ucrSelectorforProtectedColumns.Reset()

    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset

        SetDefaults()

    End Sub

    Private Sub ucrSelectorforProtectedColumns_DataFrameChanged() Handles ucrSelectorforProtectedColumns.DataFrameChanged

        ucrBase.clsRsyntax.AddParameter("data_name", Chr(34) & ucrSelectorforProtectedColumns.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34))

    End Sub

    Private Sub ucrReceiverforProtectedColumns_SelectionChanged() Handles ucrReceiverforProtectedColumns.SelectionChanged

        If Not ucrReceiverforProtectedColumns.IsEmpty Then
            ucrBase.clsRsyntax.AddParameter("col_names", ucrReceiverforProtectedColumns.GetVariableNames())
        Else
            ucrBase.clsRsyntax.AddParameter("col_names", "c()")
        End If

    End Sub


End Class