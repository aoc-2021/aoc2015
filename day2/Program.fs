open System.IO

type Gift (x:int,y:int,z:int) =
    let sideAreas = [x*y;x*z;y*z]
    let sideCircumferences = [(x+y)*2;(x+z)*2;(y+z)*2]
    let volume = x*y*z
    member this.Paper () =
        let sidePaper = sideAreas |> List.map ((*) 2) |> List.sum
        let spare = sideAreas |> List.min
        sidePaper+spare
   
    member this.Ribbon () =
       let wrap = sideCircumferences |> List.min
       let bow = volume
       wrap + bow 
     
    static member parse (s:string) =
        let [|x;y;z|] = s.Split 'x' |> Array.map int
        Gift(x,y,z)
 
let gifts = File.ReadAllLines "input.txt" |> Array.map Gift.parse |> Array.toList

gifts |> List.map (fun gift -> gift.Paper ()) |> List.sum |> printfn "Task 1: %A"
gifts |> List.map (fun gift -> gift.Ribbon ()) |> List.sum |> printfn "Task 2: %A"

