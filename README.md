# SQLI-WinForms-CSharp
Examples of how to do an SQL injection in Windows Forms applications using C#.

[![Watch the video](https://i.imgur.com/pwocAB2.png)](https://youtu.be/6t5Cjgig11g)

I made this simple program to serve as an example of how to exploit SQL Injection vulnerabilities in C# Windows Forms applications. Many people find it extremely difficult or even impossible, but here I show that it is easier than it looks and how lethal can be to your program, letting anyone execute SQL commands in your database.

## How to protect
You can read <a href="http://csharphelper.com/blog/2014/08/protect-a-program-from-sql-injection-attacks-in-c/">this article</a> and you will know how to defend yourself against this type of attack and how to make SQL injection more difficult for hackers in you application.

An example of vulnerable code in this program:
```
//Not vulnerable
MySqlCommand comand = new MySqlCommand("SELECT nome FROM users WHERE id = ?;", connection); not vulnerable
comand.Parameters.Clear();
comand.Parameters.Add("@id", MySqlDbType.Int32).Value = TxtID.Text; 
```
```
//Vulnerable
MySqlCommand comand = new MySqlCommand("SELECT nome FROM users WHERE id = "+TxtID.Text+";", connection);
```
You should never let the user add commands to your query without first validating it, as the vulnerable code demonstrates. The user could explore like this:
```
MySqlCommand comand = new MySqlCommand("SELECT nome FROM users WHERE id = "+TxtID.Text+";", connection);
SELECT nome FROM users WHERE id = 1; drop table mytable;
```
The malicious user would be breaking the line with a `;` and then log in by adding another SQL command that would be executed in your database, in which case, it would be deleting one of your tables. Unlike the non-vulnerable example, the malicious user would not be able to add a `;` to break the command.
