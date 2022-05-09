Imports System.Diagnostics
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports System.Diagnostics.CodeAnalysis

Public Class Program
    Public Shared Sub Main()
        Dim gift As String? = Nothing
        Dim address As String? = Nothing
        Dim party As String? = Nothing
        Dim sender As String? = Nothing

        If File.Exists((Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"))) = True Then
            Dim json As String = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"))
            Dim letterNode As JsonNode? = JsonNode.Parse(json)
                      
            End If

            If letterNode("sender") IsNot Nothing Then
                sender = letterNode("sender")
                                
''' 
            End If

            If letterNode("address") IsNot Nothing Then
                address = letterNode("address")
                                
            End If
        End If

        Console.Write("Thank-you note bot")
        Console.Write(vbLf)
        Console.Write("Version 1.0.0")
        Console.Write(vbLf)
        Dim attempts As Integer = 0
        Dim attempts1 As Integer = 0
        Dim done As Boolean = False
        Dim reciever As String? = "placeholder"
        Dim title As String? = "placeholder"
        Dim recognize As String? = "placeholder"
        Dim article As String? = "placeholder"
        Dim save As String? = "placeholder"

        While Not done

            If attempts > 1 Then
                Console.Write("You have redone this section " & attempts & " times.")
                Console.Write(vbLf)
            End If

            If attempts = 1 Then
                Console.Write("You have redone this section " & attempts & " time.")
                Console.Write(vbLf)
            End If

            Console.Write(vbLf)
            Console.Write("Who are you writing to?")
            Console.Write(vbLf)
            reciever = Console.ReadLine()
            Console.Write(vbLf)
            Console.Write("What gift did you get from " & reciever & "?")
            Console.Write(vbLf)

            If gift IsNot Nothing Then
                Console.Write("Imported gift """ & gift & """ from tymaker-config" & vbLf & "Skipping" & vbLf)
            Else
                gift = Console.ReadLine()
            End If

            Console.Write(vbLf)
            Console.Write("What party did you invite " & reciever & " to? (Just write the noun with no connectors)")
            Console.Write(vbLf)

            If party IsNot Nothing Then
                Console.Write("Imported party """ & party & """ from tymaker-config" & vbLf & "Skipping" & vbLf)
            Else
                party = Console.ReadLine()
                Console.Write(vbLf)
            End If

            Console.Write("Here is your letter so far:")
            Console.Write(vbLf)
            Console.Write("Dear " & reciever & "," + vbLf + vbLf & "Thank you so much for coming to my " + party & ". Thank you so much for the " + gift & ".")
            Console.Write(vbLf)
            Console.Write(vbLf)
            Console.Write("Do you like it so far? Type in ""yes"" or ""no"". " & vbLf & "Typing in ""no"" will restart this part of the creation process, and typing in ""yes"" will move you on to the next part of the creation process. " & vbLf)
            Dim continue1 As String? = Console.ReadLine()
            Console.Write(vbLf)

            Select Case continue1
                Case "yes"
                    done = True
                Case "no"
                    done = False
                    Console.Clear()
                    attempts += 1
                    Console.Write(vbLf)
                    Console.Write(vbLf)
            End Select
        End While

        Console.Write("Section 2 " & vbLf & vbLf)
        Dim done1 As Boolean = False

        While Not done1

            If attempts1 > 1 Then
                Console.Write("You have redone this section " & attempts1 & " times.")
                Console.Write(vbLf)
            End If

            If attempts1 = 1 Then
                Console.Write("You have redone this section " & attempts1 & " time.")
                Console.Write(vbLf)
            End If

            Console.Write("What do you recognize " & reciever & " as? (e.g: ""aunt"", ""friend"", ""grandfather"") " & vbLf)
            title = Console.ReadLine()
            Console.Write(vbLf)
            Console.Write(vbLf)
            Console.Write("How do you describe " & reciever & " as? (Context: 'answer' " + title & ")" & vbLf)
            recognize = Console.ReadLine()
            Console.Write(vbLf)
            Console.Write(vbLf)
            Console.Write("What article do you want to use? (Context: You are 'answer' " & recognize & " " + title & ".)" & vbLf)
            article = Console.ReadLine()
            Console.Write(vbLf)
            Console.Write(vbLf)
            Console.Write("How would you like to address " & reciever & "? (e.g: Love, From, Regards)" & vbLf)

            If address IsNot Nothing Then
                Console.Write("Imported closing """ & address & """ from tymaker-config" & vbLf & "Skipping" & vbLf)
            Else
                address = Console.ReadLine()
                Console.Write(vbLf)
            End If

            Console.Write(vbLf)
            Console.Write("What is your name?" & vbLf)
            sender = Console.ReadLine()
            Console.Write(vbLf)
            Console.Write(vbLf)
            Console.Write("Here is your letter so far:")
            Console.Write(vbLf)
            Console.Write("Dear " & reciever & "," + vbLf + vbLf & "Thank you so much for coming to my " + party & ". Thank you so much for the " + gift & ". You are " + article & " " + recognize & " " + title & "." & vbLf & vbLf + address & ", " + sender & ".")
            Console.Write(vbLf)
            Console.Write(vbLf)
            Console.Write("Do you like it so far? Type in ""yes"" or ""no"". " & vbLf & "Typing in ""no"" will restart this part of the creation process, and typing in ""yes"" will move you on to outputting your letter to a file. " & vbLf)
            Dim continue2 As String? = Console.ReadLine()
            Console.Write(vbLf)

            Select Case continue2
                Case "yes"
                    done1 = True
                Case "no"
                    done1 = False
                    Console.Clear()
                    attempts1 += 1
                    Console.Write(vbLf)
                    Console.Write(vbLf)
            End Select

            Dim done2 As Boolean = False

            While Not done2
                Console.Write("Would you like to save your letter to a text file for later use?" & vbLf & "Type in ""yes"" or ""no"". This will overwrite any text file with the same name." & vbLf)
                save = Console.ReadLine()

                Select Case save
                    Case "yes"
                        done2 = True
                    Case "no"
                        done2 = True
                        Console.Write("Exiting program..." & vbLf)
                        Environment.[Exit](0)
                    Case Else
                        done2 = False
                End Select

                Console.Write("What do you want the name of the text file to be?" & vbLf)
                Dim fileName As String? = Console.ReadLine()
                Console.Write(vbLf)
                Dim lines As String() = {"Dear " & reciever & ",", "", "Thank you so much for coming to my " & party & ". Thank you so much for the " + gift & ". You are " + article & " " + recognize & " " + title & ".", "", address & ", " + sender & "."}
                Dim docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                Using outputFile As StreamWriter = New StreamWriter(Path.Combine(docPath, fileName & ".txt"), False)

                    For Each line As String In lines
                        outputFile.WriteLine(line)
                    Next
                End Using

                Console.Write(fileName & ".txt is now saved in " & docPath & vbLf & "Do you want to open it now?" & vbLf)
                Dim openFile As String? = Console.ReadLine()

                Select Case openFile
                    Case "yes"
                        Dim p As Process = New Process()
                        Dim pi As ProcessStartInfo = New ProcessStartInfo()
                        pi.UseShellExecute = True
                        pi.FileName = Path.Combine(docPath, fileName & ".txt")
                        p.StartInfo = pi

                        Try
                            p.Start()
                        Catch __unusedException1__ As Exception
                        End Try

                    Case "no"
                        Environment.[Exit](0)
                    Case Else
                        Environment.[Exit](0)
                End Select
            End While
        End While
    End Sub
End Class
