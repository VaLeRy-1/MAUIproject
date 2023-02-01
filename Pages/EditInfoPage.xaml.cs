using AutoMapper;
using BLL.DTO;
using BLL.Services;
using PL.Models;

namespace PL.Pages;

public partial class EditInfoPage : ContentPage
{
    List<Entry> entries;
    List<string> parameters;

    public EditInfoPage()
	{
		InitializeComponent();

        UpdateInfoService updateInfo = new UpdateInfoService();

        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfoDTO, PersonalInfoViewModel>()).CreateMapper();
        PersonalInfoViewModel info = mapper.Map<PersonalInfoDTO, PersonalInfoViewModel>(updateInfo.GetUserInfo(CurrentUser.Name));

        entries = new List<Entry> { EmailEntry, NumberEntry };
        parameters = new List<string> { info.Email, info.PhoneNumber };

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].Text = parameters[i];
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
                    parameters[i] = entries[i].Text;
                }

                PersonalInfoViewModel newInfo = new PersonalInfoViewModel(parameters);

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfoViewModel, PersonalInfoDTO>()).CreateMapper();
                UpdateInfoService infoService = new UpdateInfoService();

                infoService.UpdateInfo(mapper.Map<PersonalInfoViewModel, PersonalInfoDTO>(newInfo), CurrentUser.Name);

            }

        }

        Navigation.PopAsync();
    }
}