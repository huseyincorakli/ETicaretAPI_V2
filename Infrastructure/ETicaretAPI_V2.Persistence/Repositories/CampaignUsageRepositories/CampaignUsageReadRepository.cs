﻿using ETicaretAPI_V2.Application.Repositories.CampaignUsageRepositories;
using ETicaretAPI_V2.Domain.Entities;
using ETicaretAPI_V2.Persistence.Contexts;

namespace ETicaretAPI_V2.Persistence.Repositories.CampaignUsageRepositories
{
	public class CampaignUsageReadRepository : ReadRepository<CampaignUsage>, ICampaignUsageReadRepository
	{
		public CampaignUsageReadRepository(ETicaretAPI_V2DBContext context) : base(context)
		{
		}
	}
}
