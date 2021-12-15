module Tests

open AventOfCode2
open System
open Xunit

[<Fact>]
let ``First test`` () =
    let sequence =
        seq {
            "forward 5"
            "down 5"
            "forward 8"
            "up 3"
            "down 8"
            "forward 2"
        }

    let position = sequence |> parseLines |> navigate
    Assert.Equal(15, position.x)
    Assert.Equal(60, position.y)
    Assert.Equal(900, position |> coord_toint)
