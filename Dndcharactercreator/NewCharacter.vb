Public Class NewCharacter
    ' Public variables for D&D character information
    Public CharacterName As String
    Public CharacterRace As String
    Public CharacterClass As String
    Public CharacterLevel As Integer
    Public CharacterBackground As String
    Public CharacterAlignment As String
    Public CharacterHeight As String
    Public CharacterWeight As String
    Public CharacterAge As Integer
    Public CharacterGender As String

    ' Ability scores
    Public Strength As Integer
    Public Dexterity As Integer
    Public Constitution As Integer
    Public Intelligence As Integer
    Public Wisdom As Integer
    Public Charisma As Integer

    ' Other common D&D character info
    Public HitPoints As Integer
    Public ArmorClass As Integer
    Public Speed As Integer
    Public ProficiencyBonus As Integer

    ' Descriptions for races and classes
    Private ReadOnly raceDescriptions As New Dictionary(Of String, String) From {
        {"Human", "Versatile and adaptable. Humans learn quickly and fit into many roles."},
        {"Elf", "Graceful and long-lived. Elves have keen senses and an affinity for magic and nature."},
        {"Dwarf", "Stout and hardy. Dwarves are resilient craftsmen and excellent warriors."},
        {"Halfling", "Small, nimble, and lucky. Halflings are brave and hard to intimidate."},
        {"Dragonborn", "Proud draconic humanoids. They display strong presence and a breath weapon."},
        {"Gnome", "Curious and inventive. Gnomes favor cleverness, tinkering, and illusion magic."},
        {"Half-Elf", "A blend of human versatility and elven grace, adept socially and magically."},
        {"Half-Orc", "Physically powerful and intimidating; half-orcs excel in frontline combat."},
        {"Tiefling", "Marked by infernal heritage. Tieflings often possess innate magic and charisma."}
    }

    Private ReadOnly classDescriptions As New Dictionary(Of String, String) From {
        {"Fighter", "Skilled martial combatant. Fighters master weapons, armor, and battlefield tactics."},
        {"Wizard", "Arcane scholar. Wizards cast spells learned through study and preparation."},
        {"Rogue", "Stealthy and precise. Rogues excel at sneaking, traps, and single-target strikes."},
        {"Cleric", "Divine spellcaster. Clerics heal, protect and channel powers granted by a deity."},
        {"Paladin", "Holy warrior bound by oath. Paladins combine martial skill with divine abilities."},
        {"Ranger", "Wilderness expert and hunter. Rangers track, scout, and strike favored foes."},
        {"Bard", "Charismatic performer. Bards inspire allies and manipulate magic through art."},
        {"Druid", "Keeper of nature's balance. Druids wield natural magic and can shapeshift."},
        {"Monk", "Disciplined martial artist. Monks use speed, precision, and ki to fight."},
        {"Sorcerer", "Innate spellcaster. Sorcerers draw magic from bloodlines or raw talent."},
        {"Warlock", "Pact-bound spellcaster. Warlocks gain power through a patron and eldritch magic."},
        {"Barbarian", "Primal warrior. Barbarians channel rage for extraordinary strength and resilience."}
    }

    Private Sub NewCharacter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tip As New ToolTip()

        ' Field definitions: Label text, Control type ("TextBox" or "ComboBox"), and optional items for ComboBox
        Dim fields = {
            New With {.Label = "Name", .Type = "TextBox"},
            New With {.Label = "Race", .Type = "ComboBox", .Items = New String() {"Human", "Elf", "Dwarf", "Halfling", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling"}},
            New With {.Label = "Class", .Type = "ComboBox", .Items = New String() {"Fighter", "Wizard", "Rogue", "Cleric", "Paladin", "Ranger", "Bard", "Druid", "Monk", "Sorcerer", "Warlock", "Barbarian"}},
            New With {.Label = "Level", .Type = "TextBox"},
            New With {.Label = "Background", .Type = "TextBox"},
            New With {.Label = "Alignment", .Type = "ComboBox", .Items = New String() {"Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "True Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil"}},
            New With {.Label = "Height", .Type = "TextBox"},
            New With {.Label = "Weight", .Type = "TextBox"},
            New With {.Label = "Age", .Type = "TextBox"},
            New With {.Label = "Gender", .Type = "ComboBox", .Items = New String() {"Male", "Female", "Non-binary", "Other"}}
        }

        Dim startY As Integer = 20
        Dim spacingY As Integer = 30
        Dim labelWidth As Integer = 80
        Dim controlWidth As Integer = 150

        For i = 0 To fields.Length - 1
            ' Create label
            Dim lbl As New Label()
            lbl.Text = fields(i).Label & ":"
            lbl.Left = 20
            lbl.Top = startY + i * spacingY
            lbl.Width = labelWidth
            Me.Controls.Add(lbl)

            ' Create input control
            If fields(i).Type = "TextBox" Then
                Dim txt As New TextBox()
                txt.Name = "txt" & fields(i).Label
                txt.Left = lbl.Left + labelWidth + 10
                txt.Top = lbl.Top - 2
                txt.Width = controlWidth
                Me.Controls.Add(txt)
                If fields(i).Label = "Height" Then
                    tip.SetToolTip(txt, "Height must be in feet.")
                End If
            ElseIf fields(i).Type = "ComboBox" Then
                Dim cmb As New ComboBox()
                cmb.Name = "cmb" & fields(i).Label
                cmb.Left = lbl.Left + labelWidth + 10
                cmb.Top = lbl.Top - 2
                cmb.Width = controlWidth
                cmb.DropDownStyle = ComboBoxStyle.DropDownList
                cmb.Items.AddRange(fields(i).Items)
                AddHandler cmb.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
                Me.Controls.Add(cmb)
            End If
        Next

        ' Description box under the inputs
        Dim descTop As Integer = startY + fields.Length * spacingY + 10
        Dim txtDescription As New TextBox()
        txtDescription.Name = "txtDescription"
        txtDescription.Left = 20
        txtDescription.Top = descTop
        txtDescription.Width = labelWidth + controlWidth + 10
        txtDescription.Height = 100
        txtDescription.Multiline = True
        txtDescription.ReadOnly = True
        txtDescription.ScrollBars = ScrollBars.Vertical
        txtDescription.BackColor = SystemColors.Window
        Me.Controls.Add(txtDescription)

        ' If any initial selection exists, update description
        UpdateDescription()
    End Sub

    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateDescription()
    End Sub

    Private Sub UpdateDescription()
        Dim parts As New List(Of String)

        Dim cmbRace = TryCast(Me.Controls("cmbRace"), ComboBox)
        If cmbRace IsNot Nothing AndAlso cmbRace.SelectedItem IsNot Nothing Then
            Dim raceKey = cmbRace.SelectedItem.ToString()
            If raceDescriptions.ContainsKey(raceKey) Then parts.Add("Race: " & raceKey & Environment.NewLine & raceDescriptions(raceKey))
        End If

        Dim cmbClass = TryCast(Me.Controls("cmbClass"), ComboBox)
        If cmbClass IsNot Nothing AndAlso cmbClass.SelectedItem IsNot Nothing Then
            Dim classKey = cmbClass.SelectedItem.ToString()
            If classDescriptions.ContainsKey(classKey) Then parts.Add("Class: " & classKey & Environment.NewLine & classDescriptions(classKey))
        End If

        Dim txt = TryCast(Me.Controls("txtDescription"), TextBox)
        If txt IsNot Nothing Then
            If parts.Count > 0 Then
                txt.Text = String.Join(Environment.NewLine & Environment.NewLine, parts)
            Else
                txt.Clear()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Assign values from controls to variables
        CharacterName = CType(Controls("txtName"), TextBox).Text
        CharacterRace = CType(Controls("cmbRace"), ComboBox).SelectedItem?.ToString
        CharacterClass = CType(Controls("cmbClass"), ComboBox).SelectedItem?.ToString
        Integer.TryParse(CType(Controls("txtLevel"), TextBox).Text, CharacterLevel)
        CharacterBackground = CType(Controls("txtBackground"), TextBox).Text
        CharacterAlignment = CType(Controls("cmbAlignment"), ComboBox).SelectedItem?.ToString
        CharacterHeight = CType(Controls("txtHeight"), TextBox).Text
        CharacterWeight = CType(Controls("txtWeight"), TextBox).Text
        Integer.TryParse(CType(Controls("txtAge"), TextBox).Text, CharacterAge)
        CharacterGender = CType(Controls("cmbGender"), ComboBox).SelectedItem?.ToString

        ' Build key-value pairs, only for fields that are not empty or zero
        Dim lines As New List(Of String)
        If Not String.IsNullOrWhiteSpace(CharacterName) Then lines.Add("Name=" & CharacterName)
        If Not String.IsNullOrWhiteSpace(CharacterRace) Then lines.Add("Race=" & CharacterRace)
        If Not String.IsNullOrWhiteSpace(CharacterClass) Then lines.Add("Class=" & CharacterClass)
        If CharacterLevel > 0 Then lines.Add("Level=" & CharacterLevel.ToString)
        If Not String.IsNullOrWhiteSpace(CharacterBackground) Then lines.Add("Background=" & CharacterBackground)
        If Not String.IsNullOrWhiteSpace(CharacterAlignment) Then lines.Add("Alignment=" & CharacterAlignment)
        If Not String.IsNullOrWhiteSpace(CharacterHeight) Then lines.Add("Height=" & CharacterHeight)
        If Not String.IsNullOrWhiteSpace(CharacterWeight) Then lines.Add("Weight=" & CharacterWeight)
        If CharacterAge > 0 Then lines.Add("Age=" & CharacterAge.ToString)
        If Not String.IsNullOrWhiteSpace(CharacterGender) Then lines.Add("Gender=" & CharacterGender)
        If Strength <> 0 Then lines.Add("Strength=" & Strength.ToString)
        If Dexterity <> 0 Then lines.Add("Dexterity=" & Dexterity.ToString)
        If Constitution <> 0 Then lines.Add("Constitution=" & Constitution.ToString)
        If Intelligence <> 0 Then lines.Add("Intelligence=" & Intelligence.ToString)
        If Wisdom <> 0 Then lines.Add("Wisdom=" & Wisdom.ToString)
        If Charisma <> 0 Then lines.Add("Charisma=" & Charisma.ToString)
        If HitPoints <> 0 Then lines.Add("HitPoints=" & HitPoints.ToString)
        If ArmorClass <> 0 Then lines.Add("ArmorClass=" & ArmorClass.ToString)
        If Speed <> 0 Then lines.Add("Speed=" & Speed.ToString)
        If ProficiencyBonus <> 0 Then lines.Add("ProficiencyBonus=" & ProficiencyBonus.ToString)

        ' Save to a text file (in the application's directory)
        Dim filePath = IO.Path.Combine(Application.StartupPath, "CharacterInfo.txt")
        IO.File.WriteAllLines(filePath, lines)

        MessageBox.Show("Character information saved to " & filePath, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'LOAD BUTTON ( E X P E R I M E N T A L )
    Public Sub LoadCharacterFromFile()
        Dim filePath As String = System.IO.Path.Combine(Application.StartupPath, "CharacterInfo.txt")
        If Not System.IO.File.Exists(filePath) Then
            MessageBox.Show("No saved character found.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim lines = System.IO.File.ReadAllLines(filePath)
        For Each line In lines
            Dim parts = line.Split({"="c}, 2)
            If parts.Length = 2 Then
                Dim key = parts(0)
                Dim value = parts(1)
                Select Case key
                    Case "Name" : CType(Me.Controls("txtName"), TextBox).Text = value
                    Case "Race" : CType(Me.Controls("cmbRace"), ComboBox).SelectedItem = value
                    Case "Class" : CType(Me.Controls("cmbClass"), ComboBox).SelectedItem = value
                    Case "Level" : CType(Me.Controls("txtLevel"), TextBox).Text = value
                    Case "Background" : CType(Me.Controls("txtBackground"), TextBox).Text = value
                    Case "Alignment" : CType(Me.Controls("cmbAlignment"), ComboBox).SelectedItem = value
                    Case "Height" : CType(Me.Controls("txtHeight"), TextBox).Text = value
                    Case "Weight" : CType(Me.Controls("txtWeight"), TextBox).Text = value
                    Case "Age" : CType(Me.Controls("txtAge"), TextBox).Text = value
                    Case "Gender" : CType(Me.Controls("cmbGender"), ComboBox).SelectedItem = value
                    ' Ability scores and other info can be loaded into variables if needed
                    Case "Strength" : Integer.TryParse(value, Strength)
                    Case "Dexterity" : Integer.TryParse(value, Dexterity)
                    Case "Constitution" : Integer.TryParse(value, Constitution)
                    Case "Intelligence" : Integer.TryParse(value, Intelligence)
                    Case "Wisdom" : Integer.TryParse(value, Wisdom)
                    Case "Charisma" : Integer.TryParse(value, Charisma)
                    Case "HitPoints" : Integer.TryParse(value, HitPoints)
                    Case "ArmorClass" : Integer.TryParse(value, ArmorClass)
                    Case "Speed" : Integer.TryParse(value, Speed)
                    Case "ProficiencyBonus" : Integer.TryParse(value, ProficiencyBonus)
                End Select
            End If
        Next

        ' Ensure description shows after loading selections
        UpdateDescription()
    End Sub

    ' Previous button: return to home form
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        ' If an instance of frmHome already exists, show it; otherwise create one.
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frmHome Then
                f.Show()
                Me.Close()
                Return
            End If
        Next

        Dim homeForm As New frmHome()
        homeForm.Show()
        Me.Close()
    End Sub

    ' Replace the FormClosed handler so it shows the existing home form if present
    Private Sub NewCharacter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frmHome Then
                f.Show()
                Return
            End If
        Next

        Dim homeForm As New frmHome()
        homeForm.Show()
    End Sub
End Class