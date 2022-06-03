<h1>GlobalX Coding Assessment</h1>
<p>All requirements have been satisfied except for the build pipeline task. This project was developed using <mark><strong>Microsoft Visual Studio 2019 Community Edition</strong></mark></p>
<h2>Manual Testing</h2>
<p>The compiled and published utility can be found in the <code>release</code> folder</p>
<p>Copy the entire folder to a local windows machine and from the command prompt run the following within that folder<p>
 <code>name-sorter -h</code>
 <p>This will show an overview of the options</o>
 <pre>
 
name-sorter <Input File Name> [OPTIONS...]

Where OPTIONS include:

  -h                    Show this help
  -ms                   Use the merge sort algorithm for sorting
  -so                   Supress output of sorted names
  -se                   Supress output of error messages
  -o &lt;Output File&gt;      The output file name/path. Default is sorted-names-list.txt
 </pre>
 
 <p>To test sorting of names using the required input file <code>unsorted-names-list.txt</code> use the following command:</p>
 <code>name-sorter ./unsorted-names-list.txt</code>
 <h2>Unit Testing</h2>
 <p>Clone the repository, open the command prompt and change directory to the <code>NameSorterUtiltiy</code> folder, and run <code>dotnet test</code>. This can also be done via Visual Studio's Unit Testing facilities</p>
 <p>The unit tests can be found in the <code>NameSorterUtility.Tests</code> folder.</p>
 <h2>Overview of files/classes</h2>
 <p>The project is broken up as follows:</p>
 
 Folder <code>NameSorterUtilty</code>
 contains the main <code>Program.cs</code> and <code>NameSorterUtilityControl</code> classes. The <code>NameSorterUtilityControl</code> class is the main controlling class of the console app. It is meant to resemble the MVC approach. 
 
 Folder <code>SorterLibrary</code>
 contains all of the model classes that does all the work. The project uses two sorting algorithms/approaches. The default one uses the <code>System.Collections.ArrayList.Sort()</code> algorithm. This is provided through the <code>ArrayListStringSorter</code> class that implements the <code>ISorter</code> interface. 
 
 <h3>The MergeSort Algorithm</h3>
 <p>In my confusion, I went ahead and chucked in the MergeSort algorithm as well. It implements the <code>ISorter</code> interface with the <code>MergeSortStringSorter</code> class. The MergeSort method can be used instead of the <code>ArrayList.Sort()</code> method by invoking the <code>-ms</code> option i.e. <code>name-sorter &lt;Input File Name&gt; -ms</code>.  
 
 
