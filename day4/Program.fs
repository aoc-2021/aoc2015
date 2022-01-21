

// For more information see https://aka.ms/fsharp-console-apps

open System.Security.Cryptography

printfn "Hello from F#"

let md5= MD5.Create ()
let hello = "abcdef609043".ToCharArray () |> Array.map byte 
md5.Initialize ()

let rec findFirst (n:int) =
//    printfn $"Checking {n}"
    md5.Initialize ()
    let hash = ($"yzbqklnj{n}").ToCharArray () |> Array.map byte |> md5.ComputeHash
    if hash[0] = 0uy && hash[1] = 0uy && hash[2] = 0uy then n else findFirst (n+1)
    // hash[2] < 0x10uy for task 1

let first = findFirst 1
printfn $"Task1: {first}"