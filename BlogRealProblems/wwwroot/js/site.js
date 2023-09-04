// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(document).ready(function () {
        // Quando o botão for clicado
        $("#btnExcluir").click(function () {
            // Obtenha o ID da notícia da atributo de dados (data-noticia-id)
            var noticiaId = $(this).data("noticia-id");

            // Faça a chamada para o endpoint da API usando jQuery Ajax
            $.ajax({
                type: "DELETE",
                url: "/Noticia/" + noticiaId, // Substitua pelo URL correto do seu endpoint de API
                success: function () {
                    // Lidar com a resposta bem-sucedida (por exemplo, atualizar a página)
                    location.reload();
                },
                error: function () {
                    // Lidar com erros (por exemplo, exibir uma mensagem de erro)
                    alert("Erro ao excluir a notícia.");
                }
            });
        });
    });