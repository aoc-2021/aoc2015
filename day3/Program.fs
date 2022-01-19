open System.IO

type Pos = int*int 
let dirs = File.ReadAllLines "input.txt" |> Array.head |> (fun s -> s.ToCharArray()) |> Array.toList 

let move ((x,y):Pos,visited:list<Pos>) (dir:char) =
    let pos = match dir with
              | '^' -> (x,y+1)
              | 'v' -> (x,y-1)
              | '<' -> (x-1,y)
              | '>' -> (x+1,y)
              | _ -> failwith $"Not recognized: {dir}"
    (pos,pos::visited)
    
let path (dirs) = dirs |> List.fold move ((0,0),[]) |> snd |> List.rev
let visited = path dirs |> List.groupBy id |> List.map (fun (p,ps) -> p,ps.Length)
printfn $"{path}"

printfn $"Task 1: {visited.Length}"

let rec split (dirs:list<char>) : list<char>*list<char> =
    match dirs with
    | [] -> [],[]
    | [last] -> [last],[]
    | d1::d2::rest ->
        let r1,r2 = split rest
        d1::r1,d2::r2
        
let santaDirs,robotDirs = split dirs

let visitedSanta = path santaDirs
let visitedRobot = path robotDirs

let visitedBoth = List.concat [[(0,0)];visitedSanta;visitedRobot] |> List.distinct

printfn $"Task 2: {visitedBoth.Length}"


    