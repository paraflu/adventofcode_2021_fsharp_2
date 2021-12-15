module AventOfCode2

exception InvalidDirection of string

type Command =
    | Forward_ of direction: int
    | Down of direction: int
    | Up of direction: int

type Coord = { x: int32; y: int32 }

let coord_toint (it: Coord) = it.x * it.y

let readLines filePath : seq<string> = System.IO.File.ReadLines(filePath)

let parseLines (sequence: seq<string>) : seq<Command> =
    sequence
    |> Seq.map (fun it ->
        match it with
        | s when s.StartsWith("forward") -> s.Split() |> Seq.last |> int |> Forward_
        | s when s.StartsWith("up") -> s.Split() |> Seq.last |> int |> Up
        | s when s.StartsWith("down") -> s.Split() |> Seq.last |> int |> Down
        | _ -> raise (InvalidDirection("Not supported")))

let navigate (sequence: seq<Command>) : Coord =
    sequence
    |> Seq.map (fun it ->
        match it with
        | Forward_ x -> { x = x; y = 0 }
        | Down x -> { x = 0; y = x }
        | Up x -> { x = 0; y = -x })
    |> Seq.reduce (fun curr next ->
        { x = curr.x + next.x
          y = curr.y + next.y })
