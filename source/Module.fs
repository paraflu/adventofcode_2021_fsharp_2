module AventOfCode2

exception InvalidDirection of string

type Command =
    | Forward_ of direction: int
    | Down of direction: int
    | Up of direction: int

type Coord =
    { x: int32
      y: int32
      aim: int32 }
    member self.toInt() = self.x * self.y

    member self.navigate(command: Command) =
        match command with
        | Forward_ x ->
            { x = self.x + x
              y = self.y + x * self.aim
              aim = self.aim }
        | Down y ->
            { x = self.x
              y = self.y
              aim = self.aim + y }
        | Up y ->
            { x = self.x
              y = self.y
              aim = self.aim - y }


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
    let mutable position = { x = 0; y = 0; aim = 0 }

    sequence
    |> Seq.iter (fun cmd -> position <- position.navigate (cmd))

    position
