open System
open FSharp.Data


type MoexNews = XmlProvider<"https://iss.moex.com/iss/sitenews.xml">

[<EntryPoint>]
let main argv =
    let data = MoexNews.Load "https://iss.moex.com/iss/sitenews.xml"

    #if DEBUG
    
    printfn "\n\n DEBUG \n\n"
    
    #endif

    data.Datas.[0].Rows
    |> Array.iter (fun x -> printfn "%s" x.Title.Value)

    0 // return an integer exit code
