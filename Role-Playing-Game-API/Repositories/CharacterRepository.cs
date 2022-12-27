﻿using System.Security.Claims;

namespace Role_Playing_Game_API.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterRepository(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _mapper = mapper;
    }

    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
        .FindFirstValue(ClaimTypes.NameIdentifier)!);

    public async Task<ApiResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ApiResponse<List<GetCharacterDto>>();

        var character = _mapper.Map<Character>(newCharacter);
        character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

        _context.Characters.Add(character);
        await _context.SaveChangesAsync();

        serviceResponse.Data =
            await _context.Characters
                .Where(c => c.User!.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToListAsync();
        return serviceResponse;
    }

    public async Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ApiResponse<List<GetCharacterDto>>();

        try
        {
            var character = await _context.Characters
                .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            if (character is null)
                throw new Exception($"Character with Id '{id}' not found.");

            _context.Characters.Remove(character);

            await _context.SaveChangesAsync();

            serviceResponse.Data =
                await _context.Characters
                    .Where(c => c.User!.Id == GetUserId())
                    .Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ApiResponse<List<GetCharacterDto>>();

        var dbCharacters = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .Where(c => c.User!.Id == GetUserId())
            .ToListAsync();
        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ApiResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ApiResponse<GetCharacterDto>();
        var dbCharacter = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
        return serviceResponse;
    }

    public async Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ApiResponse<GetCharacterDto>();

        try
        {
            var character =
                await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            if (character is null || character.User!.Id != GetUserId())
                throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");

            character.Name = updatedCharacter.Name;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defense = updatedCharacter.Defense;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ApiResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
        var response = new ApiResponse<GetCharacterDto>();
        try
        {
            var character = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId &&
                    c.User!.Id == GetUserId());

            if (character is null)
            {
                response.Success = false;
                response.Message = "Character not found.";
                return response;
            }

            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);
            if (skill is null)
            {
                response.Success = false;
                response.Message = "Skill not found.";
                return response;
            }

            character.Skills!.Add(skill);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterDto>(character);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }
}
