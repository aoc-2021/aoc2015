

open System.IO

let isNice (s:string) =
    let rec check (last:char) (vowels:int) (hasDuplicate:bool) (illegal:bool) (tail:list<char>) =
        match tail with
        | [] -> vowels > 2 && hasDuplicate && (not illegal) 
        | c::rest ->
            let vowels = if "aeiou".Contains c then vowels + 1 else vowels
            let hasDuplicate = hasDuplicate || last = c
            let illegal =
                match (last,c) with
                | 'a','b' -> true
                | 'c','d' -> true
                | 'p','q' -> true
                | 'x','y' -> true
                | _ -> illegal
            check c vowels hasDuplicate illegal rest  
    let s = s.ToCharArray () |> Array.toList
    check '_' 0 false false s 


File.ReadAllLines "input.txt" |> Array.filter isNice |> Array.length |> printfn "Task 1: %A" 

let isNice2 (chars:string) = 
    let rec check (pairs:Set<char*char>) (dualPair:bool) (chars:list<char>) (mirror:bool) =
        match chars with
        | a::b::c::rest ->
            let mirror = mirror || a = c
            let dualPair = dualPair || pairs.Contains (a,b) 
            let pairs = pairs.Add (a,b)
            if a = b && b = c then
                check pairs dualPair (c::rest) mirror
            else
                check pairs dualPair (b::c::rest) mirror
        | [a;b] ->
            let dualPair = dualPair || pairs.Contains (a,b)
            dualPair && mirror
        | [_] -> false
            | [] -> false
    let chars = chars.ToCharArray () |> Array.toList 
    check Set.empty false chars false 
    
File.ReadAllLines "input.txt" |> Array.filter isNice2 |> Array.length |> printfn "Task 2: %A"
        
    

    