#!/bin/bash

$score=0

Write-Host "Bienvenido al cuestionario!"

Write-Host "Pregunta 1: ?Cuál es la capital de Francia?"
Write-Host "A) Madrid"
Write-Host "B) París"
Write-Host "C) Roma"

$answer = Read-Host "Respuesta"
$answer = $answer.ToUpper()

if ($answer -eq "B") {
	$score++
}

Write-Host ""
Write-Host "Pregunta 2: ?Cuál es el resultado de 5 + 7?"
Write-Host "A) 10"
Write-Host "B) 12"
Write-Host "C) 14"

$answer = Read-Host "Respuesta"
$answer = $answer.ToUpper()

if ($answer -eq "B") {
	$score++
}

Write-Host ""
Write-Host "Pregunta 3: ?Cuál es el océano más grande del mundo?"
Write-Host "A) Atlántico"
Write-Host "B) Índico"
Write-Host "C) Pacífico"

$answer = Read-Host "Respuesta"
$answer = $answer.ToUpper()

if ($answer -eq "C") {
	$score++
}

Write-Host ""
Write-Host "Has terminado el cuestionario."
Write-Host "Tu puntuación es: $score de 3."