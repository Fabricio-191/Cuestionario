Function Clear-HostLight {
    Param ( [Parameter(Position=1)] [int32]$Count=1 )

    $CurrentLine  = $Host.UI.RawUI.CursorPosition.Y
    $ConsoleWidth = $Host.UI.RawUI.BufferSize.Width
    
    for ($i = 1; $i -le $Count; $i++) {
        [Console]::SetCursorPosition(0,($CurrentLine - $i))
        [Console]::Write("{0,-$ConsoleWidth}" -f " ")
    }

    [Console]::SetCursorPosition(0,($CurrentLine - $Count))
}
		
Function Show-Menu {
    Param ( [string]$Question, [string[]]$Options )

    $selectedIndex = 0
    $key = $null

    while ($true) {
		Write-Host $Question -ForegroundColor Cyan

        # Mostrar opciones
        for ($i = 0; $i -lt $Options.Count; $i++) {
            if ($i -eq $selectedIndex) {
                Write-Host "->  $($Options[$i])" -ForegroundColor Yellow
            } else {
                Write-Host "   $($Options[$i])" -ForegroundColor White
            }
        }

        # Capturar tecla presionada
        $key = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown").VirtualKeyCode

        # Navegación con flechas
        switch ($key) {
            38 { # Flecha hacia arriba
                if ($selectedIndex -gt 0) { $selectedIndex-- }
            }
            40 { # Flecha hacia abajo
                if ($selectedIndex -lt ($Options.Count - 1)) { $selectedIndex++ }
            }
            13 { # Enter
                return $Options[$selectedIndex]
            }
        }
		
		Clear-HostLight ($Options.Count + 1)
    }
}

$score=0

$last_answer = Show-Menu "Cual es la capital de francia?" @("Paris", "Londres", "Madrid", "Berlin")
Write-Host "

"
if ($last_answer.ToLower() -eq "Paris"){ $score += 1 }



$last_answer = Show-Menu "Cual es la capital de Alemania?" @("Paris", "Londres", "Madrid", "Berlin")
Write-Host "

"
if ($last_answer.ToLower() -eq "Berlin"){ $score += 1 }



$last_answer = Show-Menu "Cuanto es 3 * 12?" @("36", "24", "48", "12")
Write-Host "

"
if ($last_answer.ToLower() -eq "36"){ $score += 1 }



Write-Host "Despeje x de la siguiente ecuacion: 2x + 3 = 7" -ForegroundColor Cyan 

$last_answer = [int] (Read-Host "Respuesta")
Write-Host "

"
if ($last_answer -eq 2){ $score += 2 }



Write-Host "Cual es la estrella mas grande del sistema solar?" -ForegroundColor Cyan 

$last_answer = [string] (Read-Host "Respuesta")
$es = $last_answer
Write-Host "

"
if ($last_answer.ToLower() -like "*Sol*"){ $score += 1 }



Write-Host "Cual es tu edad?" -ForegroundColor Cyan 

$last_answer = [int] (Read-Host "Respuesta")
$res = $last_answer
Write-Host "

"



if ($res -lt 0){
Write-Host "Edad invalida"
}else{
Write-Host "Tu edad en meses es:" ($res * 12)
}

Write-Host "Your score is $score out of 6" -ForegroundColor Magenta 
