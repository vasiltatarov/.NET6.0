﻿using SourceControl.Data.Models;
using SourceControl.Services.Dtos;

namespace SourceControl.Services.Interfaces;

public interface IRepositoryService
{
	Task Create(Repository repo);

	Task Edit(EditRepositoryDto editModel, string userId);

	Task Delete(int id, string userId);

	Task<Repository> GetByUserId(int repoId, string userId);

	Task<IEnumerable<RepositoryDto>> GetAll(string userId);

	Task<IEnumerable<RepositoryDto>> GetAllPublic();
}
