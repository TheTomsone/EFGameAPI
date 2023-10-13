using EFGameAPI.DAL.Models;
using EFGameAPI.DB.Entities;
using EFGameAPI.Interfaces;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection;

namespace EFGameAPI.DAL.Tools
{
    public static class TransferMapper
    {
        public static TEntity ToEntity<TEntity, TModelForm>(this TModelForm modelForm, int id)
            where TEntity : class, IEntity, new()
            where TModelForm : class, IModelForm
        {
            TEntity entity = new();
            PropertyInfo[] entityProps = typeof(TEntity).GetProperties(), modelProps = typeof(TModelForm).GetProperties();

            entity.Id = id;
            for (int i = 0; i < modelProps.Length; i++)
            {
                object? value = modelProps[i].GetValue(modelForm);
                if (value is not null) entityProps[i + 1].SetValue(entity, value);
            }

            return entity;
        }
        public static TModelDTO ToDTO<TModelDTO, TEntity>(this TEntity entity)
            where TModelDTO : class, IModelDTO, new()
            where TEntity : class, IEntity
        {
            TModelDTO dto = new();
            PropertyInfo[] dtoProps = typeof(TModelDTO).GetProperties(), entityProps = typeof(TEntity).GetProperties();

            for (int i = 0; i < dtoProps.Length; i++)
            {
                if (entityProps[i].GetValue(entity) is IEnumerable<GameGenre> genres)
                    foreach (GameGenre genre in genres)
                        dtoProps[i].SetValue(dto, genre.Genre.ToDTO<GenresDTO, Genre>());

                if (entityProps[i].GetValue(entity) is IEnumerable<UserGame> games)
                    foreach (UserGame game in games)
                        dtoProps[i].SetValue(dto, game.Game.ToDTO<GameDTO, Game>());

                object? value = entityProps[i].GetValue(entity);
                if (value is not null) dtoProps[i].SetValue(dto, value);
            }

            return dto;
        }
        public static IEnumerable<TModelDTO> ToDTO<TModelDTO, TEntity>(this IEnumerable<TEntity> entities)
            where TModelDTO : class, IModelDTO, new()
            where TEntity : class, IEntity
        {
            List<TModelDTO> dtos = new();

            foreach (TEntity entity in entities)
                dtos.Add(entity.ToDTO<TModelDTO, TEntity>());

            return dtos;
        }
    }
}
        //public static Game ToDTO(this GameCreate game, int id)
        //{
        //    return new Game
        //    {
        //        Id = id,
        //        Title = game.Title,
        //        Resume = game.Resume,
        //    };
        //}

        //public static IEnumerable<GameDTO> ToDTO(this IEnumerable<Game> games)
        //{
        //    List<GameDTO> gameDTOs = new();

        //    foreach (Game game in games) gameDTOs.Add(game.ToDTO());

        //    return gameDTOs;
        //}


        //public static GameDTO ToDTO(this Game game)
        //{
        //    return new GameDTO
        //    {
        //        Id = game.Id,
        //        Title = game.Title,
        //        Resume = game.Resume,
        //        Genres = game.Genres.ToDTO(),
        //    };
        //}
        //public static GenresDTO ToDTO(this Genre genres)
        //{
        //    return new GenresDTO
        //    {
        //        Id = genres.Id,
        //        Label = genres.Label,
        //    };
        //}
        //public static List<GenresDTO> ToDTO(this List<GameGenre> gameGenre)
        //{
        //    List<GenresDTO> genres = new List<GenresDTO>();

        //    foreach (GameGenre item in gameGenre)
        //    {
        //        genres.Add(new GenresDTO { Id = item.Genre.Id, Label = item.Genre.Label });
        //    }

        //    return genres;
        //}