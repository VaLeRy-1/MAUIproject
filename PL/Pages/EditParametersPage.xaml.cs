using AutoMapper;
using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using PL.Models;

namespace PL.Pages;

public partial class EditParametersPage : ContentPage
{
    List<Entry> entries;
    List<int> parameters;

    public EditParametersPage()
    {
        InitializeComponent();

        UpdateParametersService updateParameters = new UpdateParametersService();

        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BodyParametersDTO, BodyParametersViewModel>()).CreateMapper();
        BodyParametersViewModel bodyParameters = mapper.Map<BodyParametersDTO, BodyParametersViewModel>(updateParameters.GetUserParameters(CurrentUser.Name));

        entries = new List<Entry> { WeightEntry, HeightEntry, BreastEntry, WaistEntry, HipEntry };
        parameters = new List<int> { bodyParameters.Weight, bodyParameters.Height, bodyParameters.Breast, bodyParameters.Waist, bodyParameters.Hips };
        
        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].Text = parameters[i].ToString();
        }

    }

    private void Save(object sender, EventArgs e)
    {

        for (int i = 0; i < entries.Count; i++)
        {

            if (entries[i].Text != parameters[i].ToString())
            {

                for (int j = 0; j < entries.Count; j++)
                {
                    parameters[i] = int.Parse(entries[i].Text);
                }

                BodyParametersViewModel newParameters = new BodyParametersViewModel(parameters);

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BodyParametersViewModel, BodyParametersDTO>()).CreateMapper();
                UpdateParametersService parametersService = new UpdateParametersService();

                parametersService.UpdateParameters(mapper.Map<BodyParametersViewModel, BodyParametersDTO>(newParameters), CurrentUser.Name);

            }

        }

        Navigation.PopAsync();
    }
}