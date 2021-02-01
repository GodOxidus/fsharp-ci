open System
open FSharp.Data


type MoexNews = XmlProvider<"https://iss.moex.com/iss/sitenews.xml">

[<EntryPoint>]
let main argv =
    let data = MoexNews.Load "https://iss.moex.com/iss/sitenews.xml"
    
    let secret  =  Environment.GetEnvironmentVariable "SECRET"
    printfn "%s" secret

    #if DEBUG
    
    printfn "\n\n DEBUG \n\n"
    
    #else

    data.Datas.[0].Rows
    |> Array.iter (fun x -> printfn "%s" x.Title.Value)

    #endif

    0 // return an integer exit code
