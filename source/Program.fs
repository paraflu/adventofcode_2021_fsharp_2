open AventOfCode2

readLines "input.txt"
|> parseLines
|> navigate
|> coord_toint
|> Printf.printf "AdventOfCode 2021 - day 2 - %d\n"
