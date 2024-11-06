del out\compilado\Cuestionario.exe out\Parser.cs out\Scanner.cs
(
	Coco.exe Cuestionario.ATG -namespace Cuestionario -o out
) && (cd out) && (
	csc /out:compilado/Cuestionario.exe Cuestionario.cs Scanner.cs Parser.cs SymTab.cs CodeGen.cs
) && (cd compilado) && (
	Cuestionario.exe cuestionario.txt cuestionario.bat
)