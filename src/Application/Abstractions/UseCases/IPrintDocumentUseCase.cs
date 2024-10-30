﻿using Domain.Entities;

namespace Application.Abstractions.UseCases;

public interface IPrintDocumentUseCase
{
    string Execute(Document document);
}