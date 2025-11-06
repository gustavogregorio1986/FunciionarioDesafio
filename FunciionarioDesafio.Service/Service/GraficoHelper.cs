using FunciionarioDesafio.Dominio.Dominio;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FunciionarioDesafio.Service.Service
{
    public static class GraficoHelper
    {
        public static void GerarGraficoDistribuicaoPorFuncao(List<Funcionario> funcionarios, string caminhoImagem)
        {
            var grupos = funcionarios.GroupBy(f => f.Funcao).ToList();
            int largura = 800;
            int altura = 400;
            int margemInferior = 160; // espaço extra para texto inclinado

            using var bitmap = new SKBitmap(largura, altura);
            using var canvas = new SKCanvas(bitmap);
            canvas.Clear(SKColors.White);

            // Título do gráfico
            canvas.DrawText("Distribuição de Funcionários por Função", largura / 2, 30, new SKPaint
            {
                TextSize = 20,
                Color = SKColors.Black,
                TextAlign = SKTextAlign.Center,
                IsAntialias = true
            });

            // Estilos
            var barraPaint = new SKPaint { Style = SKPaintStyle.Fill, IsAntialias = true };
            var bordaPaint = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Stroke, StrokeWidth = 2, IsAntialias = true };
            var textoPaint = new SKPaint { Color = SKColors.Black, TextSize = 12, IsAntialias = true, TextAlign = SKTextAlign.Left };

            var cores = new[] { SKColors.SteelBlue, SKColors.Teal, SKColors.Orange, SKColors.Purple, SKColors.Green, SKColors.Indigo };
            int corIndex = 0;

            int totalBarras = grupos.Count;
            int barraLargura = Math.Max(30, largura / (totalBarras * 2));
            int espacamento = Math.Max(20, (largura - totalBarras * barraLargura) / (totalBarras + 1));
            int x = espacamento;

            int maxValor = grupos.Max(g => g.Count());
            float escalaAltura = (altura - margemInferior - 50) / (float)Math.Max(maxValor, 1);

            foreach (var grupo in grupos)
            {
                int valor = grupo.Count();
                int barraAltura = (int)(valor * escalaAltura);
                int yBase = altura - margemInferior;

                barraPaint.Color = cores[corIndex % cores.Length];

                var rect = new SKRect(x, yBase - barraAltura, x + barraLargura, yBase);
                canvas.DrawRect(rect, barraPaint);
                canvas.DrawRect(rect, bordaPaint);

                // Valor acima da barra
                canvas.DrawText(valor.ToString(), x + barraLargura / 2, yBase - barraAltura - 10, new SKPaint
                {
                    TextSize = 14,
                    Color = SKColors.DarkRed,
                    TextAlign = SKTextAlign.Center,
                    IsAntialias = true
                });

                // Nome da função inclinado corretamente
                canvas.Save();
                canvas.Translate(x + barraLargura / 2, yBase + 60); // ponto de origem abaixo da barra
                canvas.RotateDegrees(-45); // aplica rotação
                canvas.DrawText(grupo.Key, 0, 0, textoPaint);
                canvas.Restore();

                x += barraLargura + espacamento;
                corIndex++;
            }

            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            File.WriteAllBytes(caminhoImagem, data.ToArray());
        }
    }
}