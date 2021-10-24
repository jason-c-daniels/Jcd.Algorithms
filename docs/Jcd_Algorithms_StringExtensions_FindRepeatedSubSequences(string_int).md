### [Jcd.Algorithms](Jcd_Algorithms.md 'Jcd.Algorithms').[StringExtensions](Jcd_Algorithms_StringExtensions.md 'Jcd.Algorithms.StringExtensions')
## StringExtensions.FindRepeatedSubSequences(string, int) Method
Given a string s return all the N-letter-long sequences (substrings)  
that occur more than once in the sequence.  
```csharp
public static System.Collections.Generic.IList<string> FindRepeatedSubSequences(this string s, int seqSize);
```
#### Parameters
<a name='Jcd_Algorithms_StringExtensions_FindRepeatedSubSequences(string_int)_s'></a>
`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The sequence to examine
  
<a name='Jcd_Algorithms_StringExtensions_FindRepeatedSubSequences(string_int)_seqSize'></a>
`seqSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The size of the repeated subsequence to seek
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
a list of repeated sequences
