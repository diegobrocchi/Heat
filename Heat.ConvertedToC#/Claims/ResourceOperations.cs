using System;
namespace Heat
{
    /// <summary>
    /// Rappresenta un potere sulla risorsa. E  definito come  Flag  quindi ammette assegnazioni cumulative, dato che il controllo viene eseguito con operazioni bitwise.
    /// Create =  0x00000001;
    /// ReadOwn = 0x00000010;
    /// ReadAll = 0x00000100;
    /// 
    /// Se myResource.AllowedOperations = ReadAll | ReadOwn (quindi ReadAll OR ReadOwn) accade che:
    /// myResource.AllowedOperations = 0x00000110  da cui: myResource.AllowedOperations and ResourceOperations.ReadOwn viene eseguito come:
    /// 0x00000110 AND 0x00000010 = 0x00000010 -> ReadOwn 
    /// http://stackoverflow.com/questions/8447/what-does-the-flags-enum-attribute-mean-in-c
    /// </summary>
    /// <remarks></remarks>
    [Flags()]
	public enum ResourceOperations
	{
		Create = 1,
		ReadOwn = 2,
		ReadAll = 4,
		UpdateOwn = 8,
		UpdateAll = 16,
		DeleteOwn = 32,
		DeleteAll = 64,
		Execute = 128
	}
}
