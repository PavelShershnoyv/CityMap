using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveMap.Application.Common.Exceptions;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Application.Common.Types;
using InteractiveMap.Application.MarkTypeService.Types;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.MarkTypeService;

public class MarkTypeService : IMarkTypeService
{
    private readonly IMapContext _context;
    private readonly IMapper _mapper;

    public MarkTypeService(IMapContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> CreateMarkType(MarkTypeRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new MarkType
        {
            Title = request.Title,
            Description = request.Description
        };

        await _context.MarkTypes.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<IEnumerable<MarkTypeBaseDto>> GetMarkTypesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.MarkTypes
            .ProjectTo<MarkTypeBaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<MarkTypeDto> GetMarkTypeAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.MarkTypes
            .Include(markType => markType.Description)
            .FirstOrDefaultAsync(markType => markType.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MarkType), id);
        }

        return _mapper.Map<MarkTypeDto>(entity);
    }

    public async Task UpdateMarkTypeAsync(int id, MarkTypeRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _context.MarkTypes.FirstOrDefaultAsync(markType => markType.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MarkType), id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteMarkTypeAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.MarkTypes.FirstOrDefaultAsync(markType => markType.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(MarkType), id);
        }

        _context.MarkTypes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
