# CentavoControl.Infrastructure

Camada tecnica para implementacoes externas.

## Responsabilidades

- implementar persistencia (ex.: EF Core + SQL Server)
- implementar repositorios concretos
- integrar servicos externos (ex.: login Google)

## Dependencias

- referencia `CentavoControl.Domain`
- referencia `CentavoControl.Application`

## Regras arquiteturais

- nao centralizar regra de negocio nesta camada
- manter foco em detalhes tecnicos e adaptadores
