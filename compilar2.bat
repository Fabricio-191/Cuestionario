(
	csc /out:compilado/Cuestionario.exe Cuestionario.cs Scanner.cs Parser.cs SymTab.cs CodeGen.cs
) && (cd compilado) && (
	Cuestionario.exe cuestionario.txt cuestionario.bat
)