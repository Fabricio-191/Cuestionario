(
	cd F:\Programacion\Cuestionario
) && (
	Coco.exe Cuestionario.ATG -namespace Cuestionario -o out
) && (cd out) && (
	csc /out:compilado/Cuestionario.exe Cuestionario.cs Scanner.cs Parser.cs SymTab.cs CodeGen.cs
) && (cd compilado) && (
	Cuestionario.exe Test.TAS
) && (del Cuestionario.exe) && (cd ..) && (del Parser.cs Scanner.cs)