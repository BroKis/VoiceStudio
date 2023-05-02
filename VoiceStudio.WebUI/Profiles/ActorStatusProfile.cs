﻿using AutoMapper;
using Sound_VoiceStudio.BLL.DTOEntitys;
using VoiceStudio.WebUI.Models.Outcoming;

namespace VoiceStudio.WebUI.Profiles;

public class ActorStatusProfile:Profile
{
    public ActorStatusProfile()
    {
        CreateMap<ActorStatusDto, ActorStatusForDisplay>();
    }
}