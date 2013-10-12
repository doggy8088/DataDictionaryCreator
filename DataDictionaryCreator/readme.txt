Data Dictionary Creator (DDC) is a simple application which helps you document SQL Server databases. It stores all the information in Extended Properties, so it's easier to keep the documentation in sync with the database as it changes.
http://www.codeplex.com/datadictionary

CREDITS
Ken Blanchard
- Bug fixes
- Screen resizing
- Table schema / owner support
- Performance increase
- Many new features...

Jon Galloway - (http://weblogs.asp.net/jgalloway)
- Original version
- Bug originiation expert

Ben Griswold - http://johnnycoder.com
- Massive user interface cleanup and code cleanup
- Converted strings to resources

Tyler Ganon - http://selectsoftwarethoughtsfromtyler.blogspot.com/
- T-SQL Export for 1.1 version

Version 1.3.4
- Fix work item #26111
- Added ClickOnce update support

Version 1.3.3
- Added sub level tabs to allow for future view, stored procedure, function, etc. documentation
- Added the possibility to exclude tables from the documentation
- Sql server 2008 is now recognized by read_previous_properties.sql
- Added additional columns to the gridview & export for more information
- Added grouped excel export. Each table is stored on a seperate worksheet
- Edited SQL xslt file to add support for unicode characters

Version 1.3.2
- Minor tweaks to existing xls templates (Column "schema" brought to first)
- Added 2 xls templates "Word Grouped" & "HTML Grouped"
- Preload all table information, this stops SMO from making unnecessary round trips, increasing performance

Version 1.3.1
- Fixed bug when adding existing additional properties

Version 1.3
- Schema/owner support. dbo.tblTest & core.tblTest will be handled as seperate tables
- Screen improvement. Window resizing will now stretch controls to take advantage of the available space
- Fixed bug when connection to SQL Server Express
- Export to SQL will now escape single quotes	
- Start menu folder will no longer be named (Default)	
- xls templates will display table schema/owner
- Other minor adjustements

Version 1.2
- Added documentation export to include tables as well as columns
- Changed Excel export from HTML based to XMLSpreadsheet based to support more than one worksheet
- Improved error handling - detection of non-DBO logins, etc.
- [UI] - tab reorganization to fit workflow a little better
- [UI] - moved feedback and progress bars to statusbar for consistency
- Support for SQL 2000 and 2005 export scripts (there were several breaking changes from 2000 to 2005)
- Limited import functionality (SQL and XML)
- Added installer

Version 1.1
- T-SQL export to allow copying documentation between database instances (thanks, Tyler!)
- Loads previously used additional properties from database on connection
- User interface enhancements
- Bug fixes
