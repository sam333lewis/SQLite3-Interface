Imports System ' For the Exception
Imports System.Windows.Forms ' For the MessageBox
Imports System.Data ' For the DataTable
Imports System.Data.SQLite ' For the SQLite interface

Class VB
        Private Sub basicSelection()
            Dim dt As DataTable = New DataTable()
                ' Creates a DataTable so that the results from the SQLite query can be stored in a table
                
            Dim SQLquery As String = "SELECT * FROM [Data Table] WHERE ID = 4;"
                ' This is to make it easier to edit the SQL query as it's out of the way
                ' Ensure to enter a semicolon at the end so SQLite knows where the end of the line is
                ' In the event that your datatable's name has spaces in it, enclose the name in square brackets so SQLite can process it
                
            Dim connection As SQLiteConnection = New SQLiteConnection("Data Source = ***")
                ' Replace the *** with the file location of the database
                ' The '@' at the start is to account for all the back-slashes in the file URL so C# doesn't through errors
                ' This is declared seperately so it can be opened and closed easily
                
            Dim command As SQLiteCommand = New SQLiteCommand()
                
            Dim reader As SQLiteDataReader
                
            Try
                connection.Open()
                        ' Opens the SQLite connection
                        
                command.Connection = connection
                        ' Sets the location of the database
                        
                command.CommandText = SQLquery
                        ' Sets the SQL query
                reader = command.ExecuteReader()
                        ' There are three types of execution, Scalar, NonQuery and Reader, for this, a Reader will do
                        
                dt.Load(reader)
                        ' Fills the DataTable with the results from the query
                        
                        ' Do Stuff Here -----> 
                        
                Dim dg As DataGridView = New DataGridView()   
                dg.DataSource = dt
                        
                        ' dg emulates a DataGridView that you may have on your form
                        ' This line of code will completely populate the DataGridView with the enire contents of the DataTable
                        ' The beauty of this is the fact that ou do not need to create columns on the DataGridView as they will be created automatically

                        '  <-----
                        
                reader.Close()
                        ' Remember to close the reader - I can't remember why though!
                        
                connection.Close()
                        ' Also remember to close the connection so that your program doesn't lock the database as SQLite can only be edited by one user at a time
                        ' You could also use connection.Dispose(); if you wanted to, depending on what you were doing
                        
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                        ' Simple messagebox giving the error message
            End Try
                ' Throw it all into a Try and Catch, just incase something goes wrong and you don't crash your program
        End Sub
    End Class
