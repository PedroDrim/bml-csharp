# bml-Csharp

[![Docker Build](https://github.com/PedroDrim/bml-csharp/actions/workflows/dotnet.yml/badge.svg?branch=errorclass)](https://github.com/PedroDrim/bml-csharp/actions)
[![CodeQL Security](https://github.com/PedroDrim/bml-csharp/actions/workflows/codeql.yml/badge.svg?branch=errorclass)](https://github.com/PedroDrim/bml-csharp/actions)
[![Codacy](https://github.com/PedroDrim/bml-csharp/actions/workflows/codacy.yml/badge.svg?branch=errorclass)](https://github.com/PedroDrim/bml-csharp/actions)

### Introdução

O objetivo deste repositório é estudar o comportamento, estrutura e o desempenho da linguagem C#.

Este repositório funciona como um plugin para o repositório princial **Benchmark Languages**.

Ferramentas utilizadas neste repositório bem como suas versões:

|Ferramenta   |Versão  |
|-------------|--------|
|.NET SDK     |9.0.101 |
|.NET Runtime |9.0.0   |
|Docker       |24.0.7  |

### Instalação

1. Clone este repositório com o comando abaixo, onde **\<branch\>** se refere ao experimento que deseja realizar:

```
git clone -b <branch> https://github.com/PedroDrim/bml-csharp
```

2. Instale o [**Docker**](https://docs.docker.com/engine/install/).

3. Entre no diretório do repositório clonado e execute o **Docker** para iniciar as simulaçoes:

```
# Gerando build docker
sudo docker build -t errorclass_csharp .

# Executando container
sudo docker run errorclass_csharp
```

4. O resultado sairá no STDOUT no seguinte formato:

```
{
    "Read@0":67,
    "SummaryAnalysis@0":1,
    "MergeAnalysis@0":72,
    "QuickAnalysis@0":65,
    "LanguageAnalysis@0":19
}
```

### Garantia de Qualidade

Este é um pequeno checklist para que eu garanta que a simulação irá funcionar seguindo os seguintes critérios de qualidade:

- [x] Possui teste automatizado?
- [x] Os testes automatizados funcionam corretamente?
- [x] Possui arquivo de simulação (Bench.sh)?
- [x] O arquivo de simulação (Bench.sh) funciona corretamente?
- [x] Possui **Dockerfile**?
- [x] O arquivo **Dockerfile** funciona corretamente?
- [x] O repositório possui um passo-a-passo de como executar a simulação?
- [x] Esta simulação está contida em um branch individual?
- [x] Esta simulação possui um **release**?

### Experimentos

Esta seção é a mais divertida (na minha opinião), pois nela descrevo os experimentos realizados com as linguagens bem como as técnicas utilizadas para as respectivas análises.

| Nome (com link) | Objetivo | Técnicas utilizadas para análise |
|-----------------|----------|----------------------------------|
| [simpleclass](https://github.com/PedroDrim/Benchmark-Languages/blob/simpleclass/Documents/simpleclass.md) | Estudar a criação de classes simples | Scatterplot de média com desvio padrão e regressão linear simples.|
| [inputclass](https://github.com/PedroDrim/Benchmark-Languages/blob/master/outputs/inputclass/inputclass.md) | Estudar a leitura de arquivos e interfaces | Análise por média e exibição por Barplot estacado |
| [erroclass](https://github.com/PedroDrim/Benchmark-Languages/blob/master/outputs/errorclass/errorclass.md) | Estudar o tratamento de excessões | Análise por média com desvio padrão e exibição de ScatterPlot |
