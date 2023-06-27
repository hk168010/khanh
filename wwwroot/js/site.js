$(() => {
    LoadProData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();
    connection.start();
    connection.on("LoadMovies", function () {
        LoadProData();
    })
    LoadProData();
    function LoadProData() {
        var tr = '';
        $.ajax({
            url: '/Movies/Index/GetMovies',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>               
                        <td>${v.movieName}</td>
                        <td>${v.year}</td>
                        <td>${v.runningTime}</td>
                         <td>${v.rating}</td>             
                         <td>
                            <a href='../Movies/Edit?id=${v.movieID}'>Edit</a>
                            <a href='../Movies/Details?id=${v.movieID}'>Details</a>
                            <a href='../Movies/Delete?id=${v.movieID}'>Delete</a>
                        </td>
                    </tr>`
                })
                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log("signalr js err: "+error)
            }

        });
    }
})
