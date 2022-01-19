open System.IO

let steps = File.ReadAllLines "input.txt"
            |> Array.head
            |> (fun s -> s.ToCharArray ())
            |> Array.toList
            |> List.map (fun c -> if c = '(' then 1 elif c = ')' then -1 else failwith $"Unrecognized character: {c}")

// part 1 
steps |> List.fold (fun a c -> a + c) 0 |> printfn "Solution: %A"

// part 2
let rec search (pos:int) (floor:int) (steps:list<int>) =
    if floor = -1 then pos
    else search (pos+1) (floor+steps.Head) (steps.Tail) 
search 0 0 steps |> printfn "Solution 2: %A"
   