$score=0

Write-Host "Cual es la capital de francia ?" -ForegroundColor Yellow 
Write-Host "-> Paris"
Write-Host "-> Londres"
Write-Host "-> Madrid"
Write-Host "-> Berlin"

$last_answer = Read-Host "
Respuesta"
if ($last_answer.ToLower() -eq "Paris"){ $score += 1 }



Write-Host "

"
Write-Host "Cual es la capital de Alemania ?" -ForegroundColor Yellow 
Write-Host "-> Paris"
Write-Host "-> Londres"
Write-Host "-> Madrid"
Write-Host "-> Berlin"

$last_answer = Read-Host "
Respuesta"
if ($last_answer.ToLower() -eq "Berlin"){ $score += 1 }



Write-Host "

"
Write-Host "Cuanto es 3 * 12 ?" -ForegroundColor Yellow 
Write-Host "-> 36"
Write-Host "-> 24"
Write-Host "-> 48"
Write-Host "-> 12"

$last_answer = Read-Host "
Respuesta"
if ($last_answer.ToLower() -eq "36"){ $score += 1 }



Write-Host "

"
Write-Host "Despeje la siguiente ecuacion: 2x + 3 = 7" -ForegroundColor Yellow 

$last_answer = Read-Host "
Respuesta"
if ($last_answer -notmatch "^\d+$"){
  Throw "Invalid input. Please enter a number"
}

if ($last_answer.ToLower() -eq "2"){ $score += 2 }



Write-Host "

"
Write-Host "Cual es la estrella mas grande del sistema solar ?" -ForegroundColor Yellow 

$last_answer = Read-Host "
Respuesta"
$es = $last_answer
if ($last_answer.ToLower() -like "*Sol*"){ $score += 1 }



Write-Host "

"
Write-Host "Cual es tu edad ?" -ForegroundColor Yellow 

$last_answer = Read-Host "
Respuesta"
if ($last_answer -notmatch "^\d+$"){
  Throw "Invalid input. Please enter a number"
}

$res = $last_answer



if ($res -lt 0){
Write-Host "Edad invalida"}else{
Write-Host "Tu edad en meses es: " ($res * 12)}

Write-Host "Your score is $score out of 6"
